using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblQuestion
    {
        public tblQuestion()
        {
            this.tblExamStructs = new List<tblExamStruct>();
            this.tblLinks = new List<tblLink>();
            this.tblSuggestions = new List<tblSuggestion>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Contents { get; set; }
        public string Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string Solution { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> FormID { get; set; }
        public Nullable<int> LevelId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual ICollection<tblExamStruct> tblExamStructs { get; set; }
        public virtual tblForm tblForm { get; set; }
        public virtual ICollection<tblLink> tblLinks { get; set; }
        public virtual ICollection<tblSuggestion> tblSuggestions { get; set; }
    }
}
