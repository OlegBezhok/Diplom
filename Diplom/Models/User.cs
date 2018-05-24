using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Diplom.Models
{
    public class User : IdentityUser
    {    
        public string Role { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public User()
        {
            Answers = new List<Answer>();
        }
    }
}