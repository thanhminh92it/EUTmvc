using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblSubtest
    {
        public tblSubtest()
        {
            this.tblCategories = new List<tblCategory>();
            this.tblStructs = new List<tblStruct>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int QuestionNumber { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual ICollection<tblCategory> tblCategories { get; set; }
        public virtual ICollection<tblStruct> tblStructs { get; set; }
    }
}
