using Diplom.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        [Authorize]
        public ActionResult Index(string item_id)
        {
            bool user = HttpContext.User.IsInRole("employee");
            List<Question> questions= new List<Question>();
            List<Answer> questionAnswers = new List<Answer>();
            if (user)
            {
                questions = db.Questions.Where(x => x.Variant == 1).ToList();
                foreach (var question in questions)
                {
                    questionAnswers.Add(new Answer { Question = question, QuestionId = question.Id, UserMail = HttpContext.User.Identity.Name });
                    
                }
            }
            else
            {
                questions = db.Questions.Where(x => x.Variant == 2).ToList();
                foreach (var question in questions)
                {
                    questionAnswers.Add(new Answer { Question = question, QuestionId = question.Id, EmplMail = item_id, UserMail = HttpContext.User.Identity.Name });
                }
            }
            return View(questionAnswers);
        }
        [HttpPost]
        public ActionResult Index(List<Answer> answer)
        {
            foreach (var ans in answer)
            {
                ans.Question = db.Questions.FirstOrDefault(x => x.Id == ans.QuestionId);
                ans.DateTime = DateTime.Now.Year;
                ans.User = db.Users.FirstOrDefault(x => x.Email == ans.UserMail);
                
                db.Answers.Add(new Answer { Mark = ans.Mark, DateTime = ans.DateTime, EmplMail = ans.EmplMail, Question = ans.Question, Comment = ans.Comment, QuestionId = ans.QuestionId, User = ans.User, UserMail = ans.UserMail });
                db.SaveChanges();
            }

            return RedirectToAction("Answer");
        }
        [Authorize(Roles = "manager,hr")]
        public ActionResult Choose()
        {
            var users = db.Users.Where(x => x.Role == "employee").ToList();
            
            return View(users);
        }
        [HttpPost]        
        public ActionResult Choose(string email1, string button, int? year, string email2)
        {
            if (button == "question")
            {
                
                return RedirectToAction("Index", new { item_id = email1 });
            }
            else 
            {
                return RedirectToAction("Analytics", new { item_id = email2, year = year });
            }
            
        }
        [Authorize]
        public ActionResult Answer()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Answer")]
        public ActionResult AnswerRedirect()
        {
            return RedirectToAction("Choose");
        }

        [Authorize(Roles = "hr")]
        public ActionResult Analytics(string item_id, int? year)
        {
            
            User employee = db.Users.FirstOrDefault(x => x.Email == item_id);
            List<Answer> answers = new List<Answer>();

            if (item_id != null)
            {
                answers.AddRange(db.Answers.Where(x => x.EmplMail == item_id && x.DateTime == year));
            }
            else
            {
                answers.AddRange(db.Answers.Where(x => x.DateTime == year));
            }
            
            List<int> markHr = new List<int>();
            List<int> markEmp = new List<int>();
            List<int> markMan = new List<int>();
            
            double averageMan = 0;
            double averageEmp= 0;
            double averageHr = 0;
            string comment = null;
            foreach (var answer in answers)
            {
                if (db.Users.FirstOrDefault(x => x.Email == answer.UserMail).Role == "hr")
                {
                    markHr.Add(answer.Mark);
                    averageHr += answer.Mark;
                }
                else if (db.Users.FirstOrDefault(x => x.Email == answer.UserMail).Role == "manager")
                {
                    markMan.Add(answer.Mark);
                    averageMan += answer.Mark;
                }
                else
                {
                    markEmp.Add(answer.Mark);
                    averageEmp += answer.Mark;
                }
                if (answer.Comment != null)
                {
                    comment = answer.Comment;
                }
            }
            averageEmp = Math.Round(averageEmp / markEmp.Count());
            averageMan = Math.Round(averageMan / markMan.Count());
            averageHr = Math.Round(averageHr / markHr.Count());
            
            AnalyticsModel analytics =new  AnalyticsModel()
                { AverageMarkEmp = averageEmp, MarkEmp = markEmp, AverageMarkHr = averageHr,
                AverageMarkMan = averageMan, MarkHr = markHr, MarkMan = markMan, Comment = comment,
                ResultEmp = Helper.Gradation.DoGradation(averageEmp) , ResultHr = Helper.Gradation.DoGradation(averageHr),
                ResultMan = Helper.Gradation.DoGradation(averageMan) };
            return View(analytics);
        }
    }
}