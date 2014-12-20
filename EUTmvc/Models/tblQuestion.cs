using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblQuestion
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> LevelId { get; set; }
        public Nullable<int> FormId { get; set; }
        public string Contents { get; set; }
        public string Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string AnswerDetail { get; set; }
        public Nullable<int> SuggestionId { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual tblForm tblForm { get; set; }
        public virtual tblLevel tblLevel { get; set; }
        public virtual tblSuggestion tblSuggestion { get; set; }
    }
}
