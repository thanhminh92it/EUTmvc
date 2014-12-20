using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblForm
    {
        public tblForm()
        {
            this.tblChallenges = new List<tblChallenge>();
            this.tblExamStructs = new List<tblExamStruct>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> Time { get; set; }
        public Nullable<double> Request { get; set; }
        public Nullable<int> QuestionNumber { get; set; }
        public virtual ICollection<tblChallenge> tblChallenges { get; set; }
        public virtual ICollection<tblExamStruct> tblExamStructs { get; set; }
    }
}
