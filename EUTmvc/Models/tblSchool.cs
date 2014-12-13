using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblSchool
    {
        public tblSchool()
        {
            this.tblPersons = new List<tblPerson>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
        public int CountryId { get; set; }
        public int AreaId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblArea tblArea { get; set; }
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblDistrict tblDistrict { get; set; }
        public virtual ICollection<tblPerson> tblPersons { get; set; }
    }
}
