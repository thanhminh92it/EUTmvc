using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblDegree
    {
        public tblDegree()
        {
            this.tblPersons = new List<tblPerson>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual ICollection<tblPerson> tblPersons { get; set; }
    }
}
