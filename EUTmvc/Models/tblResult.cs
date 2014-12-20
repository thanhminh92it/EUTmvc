using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblResult
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> ExamQuestionId { get; set; }
        public Nullable<int> Seed { get; set; }
        public string Answer { get; set; }
        public Nullable<System.DateTime> ExecutionTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Point { get; set; }
        public Nullable<int> AccumulatedPoints { get; set; }
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblExamQuestion tblExamQuestion { get; set; }
    }
}
