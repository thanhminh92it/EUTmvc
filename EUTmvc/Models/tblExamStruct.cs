using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblExamStruct
    {
        public tblExamStruct()
        {
            this.tblExamQuestions = new List<tblExamQuestion>();
            this.tblStructContents = new List<tblStructContent>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> FormId { get; set; }
        public Nullable<int> GradeId { get; set; }
        public Nullable<int> EasyNumber { get; set; }
        public Nullable<int> AverageNumber { get; set; }
        public Nullable<int> HardNumber { get; set; }
        public Nullable<int> CategoryNumber { get; set; }
        public Nullable<int> QuestionNumber { get; set; }
        public Nullable<int> Time { get; set; }
        public Nullable<double> Request { get; set; }
        public Nullable<int> SubtestId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual ICollection<tblExamQuestion> tblExamQuestions { get; set; }
        public virtual tblForm tblForm { get; set; }
        public virtual tblSubtest tblSubtest { get; set; }
        public virtual ICollection<tblStructContent> tblStructContents { get; set; }
    }
}
