using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblNew
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string News { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
    }
}
