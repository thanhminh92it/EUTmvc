using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblPerson
    {
        public tblPerson()
        {
            this.tblAccounts = new List<tblAccount>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> Sex { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> DegreeId { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual ICollection<tblAccount> tblAccounts { get; set; }
        public virtual tblDegree tblDegree { get; set; }
        public virtual tblSchool tblSchool { get; set; }
    }
}
