using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblExamQuestion
    {
        public tblExamQuestion()
        {
            this.tblChallenges = new List<tblChallenge>();
            this.tblResults = new List<tblResult>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int ExamStructId { get; set; }
        public string QuestionId { get; set; }
        public Nullable<int> AccumulatedPoints { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual ICollection<tblChallenge> tblChallenges { get; set; }
        public virtual tblExamStruct tblExamStruct { get; set; }
        public virtual ICollection<tblResult> tblResults { get; set; }
    }
}
