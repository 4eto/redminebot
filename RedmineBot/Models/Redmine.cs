using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedmineBot.Models
{
    [Table("redmines")]
    public class Redmine
    {
        public Redmine()
        {
            Users = new List<User>();
        }

        [Column(name: "remineid")]
        public int RedmineId { get; set; }
        [Column(name: "name", TypeName = "varchar")]
        public string Name { get; set; }
        [Column(name: "url", TypeName = "varchar")]
        public string URL { get; set; }
        [Column(name: "password", TypeName = "varchar")]
        public string Passwrod { get; set; }
        [Column(name: "login", TypeName = "varchar")]
        public string Login { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}