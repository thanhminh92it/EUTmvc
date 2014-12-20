using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblChallenge
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Nullable<int> RivalId { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> FormId { get; set; }
        public int AccumulatedPoints { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ExamQuestionId { get; set; }
        public Nullable<int> ResultId { get; set; }
        public Nullable<int> ResultRivalId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual tblExamQuestion tblExamQuestion { get; set; }
        public virtual tblForm tblForm { get; set; }
    }
}
