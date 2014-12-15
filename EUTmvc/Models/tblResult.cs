using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblResult
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<int> IdAccount { get; set; }
        public Nullable<int> IdExamQuestion { get; set; }
        public string Answer { get; set; }
        public Nullable<double> Point { get; set; }
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblExamQuestion tblExamQuestion { get; set; }
    }
}
