using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblTestResultsContent
    {
        public int Id { get; set; }
        public int TestResultId { get; set; }
        public int ExamStructId { get; set; }
        public string Answers { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblExamStruct tblExamStruct { get; set; }
        public virtual tblTestResult tblTestResult { get; set; }
    }
}
