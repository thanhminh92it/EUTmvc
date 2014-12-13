using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EUTmvc.Models
{
    public class FileClass
    {
        public HttpPostedFileBase file { get; set; }
        public string path { get; set; }
    }
}