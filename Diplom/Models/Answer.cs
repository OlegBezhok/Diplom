using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int Mark { get; set; }
        public string UserMail { get; set; }
        public int QuestionId { get; set; }        
        public int DateTime { get; set; }
        public string EmplMail { get; set; }
        public string Comment { get;set; }
        
        public Question Question { get; set; }
        public User User { get; set; }        
    }
}