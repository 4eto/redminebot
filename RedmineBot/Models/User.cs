using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedmineBot.Models
{
    [Table("users")]
    public class User
    {
        public User()
        {
            Issues = new List<Issue>();
            Redmines = new List<Redmine>();
        }
        [Column(name: "userid")]
        public int UserId { get; set; }
        [Column(name: "name", TypeName = "varchar")]
        public string Name { get; set; }
        [Column(name: "apikey", TypeName = "varchar")]
        public string APIKey { get; set; }

        public virtual ICollection<Issue> Issues { get; protected set; }
        public virtual ICollection<Redmine> Redmines { get; protected set; }

        public void SetIssueMuted(Issue issue)
        {

        }
    }
}