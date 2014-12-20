using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblStructContent
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ExamStructId { get; set; }
        public int CategoryId { get; set; }
        public int EasyNumber { get; set; }
        public int AverageNumber { get; set; }
        public int HardNumber { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual tblExamStruct tblExamStruct { get; set; }
    }
}
