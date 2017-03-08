using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedmineBot.Models
{
    [Table("issues")]
    public class Issue
    {
        [Column(name: "issueid")]
        public int IssueId { get; set; }
        [Column(name: "title", TypeName = "varchar")]
        public string Title { get; set; }
        [Column(name: "description", TypeName = "varchar")]
        public string Description { get; set; }
        [Column(name: "started", TypeName = "datetime")]
        public DateTime? Started { get; set; }
        [Column(name: "duedate", TypeName = "datetime")]
        public DateTime? Duedate { get; set; }
        [Column(name: "priority")]
        public int Priority { get; set; }
        [Column(name: "ismuted", TypeName = "bit")]
        public bool Muted { get; set; }
    }
}