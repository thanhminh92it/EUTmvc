using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblForm
    {
        public tblForm()
        {
            this.tblQuestions = new List<tblQuestion>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<tblQuestion> tblQuestions { get; set; }
    }
}
