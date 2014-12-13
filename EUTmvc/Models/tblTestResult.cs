using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblTestResult
    {
        public tblTestResult()
        {
            this.tblTestResultsContents = new List<tblTestResultsContent>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public int ExamQuestionId { get; set; }
        public Nullable<System.DateTime> ExecutionTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Point { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblExamQuestion tblExamQuestion { get; set; }
        public virtual ICollection<tblTestResultsContent> tblTestResultsContents { get; set; }
    }
}
