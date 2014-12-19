using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblGrade
    {
        public tblGrade()
        {
            this.tblExamStructs = new List<tblExamStruct>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<tblExamStruct> tblExamStructs { get; set; }
    }
}
