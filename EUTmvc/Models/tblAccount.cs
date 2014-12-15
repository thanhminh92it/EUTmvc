using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblAccount
    {
        public tblAccount()
        {
            this.tblResults = new List<tblResult>();
        }

        public int Id { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string Image { get; set; }
        public string EmailCode { get; set; }
        public int StatusAccountId { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> NewTime { get; set; }
        public int GroupAcountId { get; set; }
        public int PersonId { get; set; }
        public Nullable<double> Point { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblGroupAcount tblGroupAcount { get; set; }
        public virtual tblPerson tblPerson { get; set; }
        public virtual tblStatusAccount tblStatusAccount { get; set; }
        public virtual ICollection<tblResult> tblResults { get; set; }
    }
}
