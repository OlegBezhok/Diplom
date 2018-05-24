using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Diplom.Models
{
    

    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
        
    }
}