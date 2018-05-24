using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем роли
            var role1 = new IdentityRole { Name = "hr" };
            var role2 = new IdentityRole { Name = "manager" };
            var role3 = new IdentityRole { Name = "employee" };
            
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);


            // создаем пользователей
            var hr0 = new User { Email = "akulaeva", UserName = "akulaeva", Role = "hr", Name= "Алина Кулаева" };
            string password0 = "akulaeva";
            var hr1 = new User { Email = "adoroshkevich", UserName = "adoroshkevich", Role = "hr", Name = "Анна Дорошкевич" };
            string password1 = "adoroshkevich";

            var manager0 = new User { Email = "ilashch", UserName = "ilashch" , Role = "manager", Name = "Илья Лащ" };
            string passwordManager0 = "ilashch";
            var manager1 = new User { Email = "pbruyako", UserName = "pbruyako", Role = "manager", Name= "Павел Бруяко" };
            string passwordManager1 = "pbruyako";
            var manager2 = new User { Email = "wbukato", UserName = "wbukato", Role = "manager", Name= "Виктор Букато" };
            string passwordManager2 = "wbukato";
            var manager3 = new User { Email = "avalmus", UserName = "avalmus", Role = "manager", Name= "Артем Вальмус" };
            string passwordManager3 = "avalmus";
            var manager4 = new User { Email = "svolynez", UserName = "svolynez", Role = "manager", Name = "Сергей Волынец" };
            string passwordManager4 = "svolynez";

            var employee0 = new User { Email = "abolgar", UserName = "abolgar", Role = "employee", Name = "Артем Болгар" };
            string passwordEmployee0 = "abolgar";
            var employee1 = new User { Email = "aborisova", UserName = "aborisova", Role = "employee", Name= "Анастасия Борисова" };
            string passwordEmployee1 = "aborisova";
            var employee2 = new User { Email = "abordyukov", UserName = "abordyukov", Role = "employee", Name = "Андрей Бордюков" };
            string passwordEmployee2 = "abordyukov";
            var employee3 = new User { Email = "agorbel", UserName = "agorbel", Role = "employee", Name = "Алексей Горбель" };
            string passwordEmployee3 = "agorbel";
            var employee4 = new User { Email = "agribkov", UserName = "agribkov", Role = "employee", Name = "Андрей Грибков" };
            string passwordEmployee4 = "agribkov";
            var employee5 = new User { Email = "agrigorevich", UserName = "agrigorevich", Role = "employee", Name = "Александр Григоревич" };
            string passwordEmployee5 = "agrigorevich";
            var employee6 = new User { Email = "kgulin", UserName = "kgulin", Role = "employee", Name= "Кирилл Гулин" };
            string passwordEmployee6 = "kgulin";
            var employee7 = new User { Email = "vgurin", UserName = "vgurin", Role = "employee", Name= "Вадим Гурин" };
            string passwordEmployee7 = "vgurin";
            var employee8 = new User { Email = "kdeshkevich", UserName = "kdeshkevich", Role = "employee", Name= "Кирилл Дешкевич" };
            string passwordEmployee8 = "kdeshkevich";
            var employee9 = new User { Email = "adovguchits", UserName = "adovguchits", Role = "employee", Name= "Анастасия Довгучиц" };
            string passwordEmployee9 = "adovguchits";
            var employee10 = new User { Email = "azhuk", UserName = "azhuk", Role = "employee", Name= "Артем Жук" };
            string passwordEmployee10 = "svolynez";

            var result = userManager.Create(hr0, password0);
            userManager.Create(hr1, password1);
            userManager.Create(manager0, passwordManager0);
            userManager.Create(manager1, passwordManager1);
            userManager.Create(manager2, passwordManager2);
            userManager.Create(manager3, passwordManager3);
            userManager.Create(manager4, passwordManager4);

            userManager.Create(employee0, passwordEmployee0);
            userManager.Create(employee1, passwordEmployee1);
            userManager.Create(employee2, passwordEmployee2);
            userManager.Create(employee3, passwordEmployee3);
            userManager.Create(employee4, passwordEmployee4);
            userManager.Create(employee5, passwordEmployee5);
            userManager.Create(employee6, passwordEmployee6);
            userManager.Create(employee7, passwordEmployee7);
            userManager.Create(employee8, passwordEmployee8);
            userManager.Create(employee9, passwordEmployee9);
            userManager.Create(employee10, passwordEmployee10);
            var question1 = new Question { Variant = 1, Text = "Удовлетворенность условиями труда" };
            var question2 = new Question { Variant = 1, Text = "Уровень удовлетворенности проектом" };
            var question3 = new Question { Variant = 1, Text = "Уровень удовлетворенности социальным пакетом" };
            var question4 = new Question { Variant = 1, Text = "Уровень удовлетворенности корпоративными мероприятиями" };
            var question5 = new Question { Variant = 1, Text = "Находишь общий язык и взаимопонимание в команде " };
            var question6 = new Question { Variant = 1, Text = "Отношения с непосредственным руководством" };
            var question7 = new Question { Variant = 1, Text = "Удовлетворен стилем и методами работы руководителя" };
            var question8 = new Question { Variant = 1, Text = "Взаимодействие с руководителем эффективно: руководитель ставит цели" };
            var question9 = new Question { Variant = 1, Text = "Взаимодействие с руководителем эффективно: направляет " };
            var question10 = new Question { Variant = 1, Text = "Взаимодействие с руководителем эффективно: отслеживает исполнение" };
            var question11 = new Question { Variant = 1, Text = "Взаимодействие с руководителем эффективно: предоставляет обратную связб" };
            var question12 = new Question { Variant = 1, Text = "Не скрываешь своих ошибок и слабостей, сообщаешь о проблемах" };
            var question13 = new Question { Variant = 1, Text = "Удовлетворен перспективами карьерного роста" };
            var question14 = new Question { Variant = 1, Text = "Заработная плата соответсвует моему вкладу и профессионализму" };
            var question15 = new Question { Variant = 1, Text = "Поставленные задачи соответствуют моим интересам" };
            var question16 = new Question { Variant = 1, Text = "Чувствую уверенность в завтрашнем дне, работая в компании" };
            var question17 = new Question { Variant = 1, Text = "Понимаю цели, ценности компании" };
            var question18 = new Question { Variant = 1, Text = "Удовлетворен возможностью влиять на эффективность работы подразделения" };
            var question19 = new Question { Variant = 1, Text = "Удовлетворен механизмами контроля сотрудников в организации" };

            var question01 = new Question { Variant = 2, Text = "Сотрудник удовлетворен условиями труда" };
            var question02 = new Question { Variant = 2, Text = "Сотрудник удовлетворен проектом" };
            var question03 = new Question { Variant = 2, Text = "Сотрудник проявляет интерес к проекту" };
            var question04 = new Question { Variant = 2, Text = "Сотрудник удовлетворен социльным пакетом" };
            var question05 = new Question { Variant = 2, Text = "Сотрудник удовлетворен корпоративными мероприятиями" };
            var question06 = new Question { Variant = 2, Text = "Сотрудник находит общий язык и взаимопонимание в команде" };
            var question07 = new Question { Variant = 2, Text = "Сотрудник удовлетворен отношениями с непосредственным руководством" };
            var question08 = new Question { Variant = 2, Text = "Сотрудник удовлетворен стилем и методами работы руководителя" };
            var question09 = new Question { Variant = 2, Text = "Сотрудник не скрывает своих ошибок и слабостей, сообщает о проблемах" };
            var question010 = new Question { Variant = 2, Text = "Сотрудник удовлетворен перспективами карьерного роста" };
            var question011 = new Question { Variant = 2, Text = "Поставленные задачи соответствуют интересам сотрудника" };
            var question012 = new Question { Variant = 2, Text = "Сотрудник чувствует уверенность в завтрашнем дне, работая в компании" };
            var question013 = new Question { Variant = 2, Text = "Сотрудник понимает цели, ценности компании" };
            var question014 = new Question { Variant = 2, Text = "Сотрудник имеет возможность влиять на эффективность работы подразделения" };
            var question015 = new Question { Variant = 2, Text = "Сотрудник удовлетворен механизмами контроля в организации" };
            context.Questions.Add(question19);
                context.Questions.Add(question18);
                context.Questions.Add(question17);
                context.Questions.Add(question16);
                context.Questions.Add(question15);
                context.Questions.Add(question14);
                context.Questions.Add(question13);
                context.Questions.Add(question12);
                context.Questions.Add(question11);
                context.Questions.Add(question10);
                context.Questions.Add(question9);
                context.Questions.Add(question8);
                context.Questions.Add(question7);
                context.Questions.Add(question6);
                context.Questions.Add(question5);
                context.Questions.Add(question4);
                context.Questions.Add(question3);
                context.Questions.Add(question2);
                context.Questions.Add(question1);
            context.Questions.Add(question015);
            context.Questions.Add(question014);
            context.Questions.Add(question013);
            context.Questions.Add(question012);
            context.Questions.Add(question011);
            context.Questions.Add(question010);
            context.Questions.Add(question09);
            context.Questions.Add(question08);
            context.Questions.Add(question07);
            context.Questions.Add(question06);
            context.Questions.Add(question05);
            context.Questions.Add(question04);
            context.Questions.Add(question03);
            context.Questions.Add(question02);
            context.Questions.Add(question01);
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(hr0.Id, role1.Name);
                userManager.AddToRole(hr1.Id, role1.Name);

                userManager.AddToRole(manager0.Id, role2.Name);
                userManager.AddToRole(manager1.Id, role2.Name);
                userManager.AddToRole(manager2.Id, role2.Name);
                userManager.AddToRole(manager3.Id, role2.Name);
                userManager.AddToRole(manager4.Id, role2.Name);

                userManager.AddToRole(employee0.Id, role3.Name);
                userManager.AddToRole(employee1.Id, role3.Name);
                userManager.AddToRole(employee2.Id, role3.Name);
                userManager.AddToRole(employee3.Id, role3.Name);
                userManager.AddToRole(employee4.Id, role3.Name);
                userManager.AddToRole(employee5.Id, role3.Name);
                userManager.AddToRole(employee6.Id, role3.Name);
                userManager.AddToRole(employee7.Id, role3.Name);
                userManager.AddToRole(employee8.Id, role3.Name);
                userManager.AddToRole(employee9.Id, role3.Name);
                userManager.AddToRole(employee10.Id, role3.Name);              

            }

            base.Seed(context);
        }
    }
}