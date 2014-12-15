using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblQuestion
    {
        public tblQuestion()
        {
            this.tblExamQuestions = new List<tblExamQuestion>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Contents { get; set; }
        public Nullable<int> IdCategory { get; set; }
        public Nullable<int> IdLevel { get; set; }
        public string Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public Nullable<int> IdSuggestion { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual ICollection<tblExamQuestion> tblExamQuestions { get; set; }
        public virtual tblLevel tblLevel { get; set; }
        public virtual tblSuggestion tblSuggestion { get; set; }
    }
}
