using System;
using System.Collections.Generic;

namespace EUTmvc.Models
{
    public partial class tblCategory
    {
        public tblCategory()
        {
            this.tblChallenges = new List<tblChallenge>();
            this.tblQuestions = new List<tblQuestion>();
            this.tblStructContents = new List<tblStructContent>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SubtestId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedCount { get; set; }
        public virtual tblSubtest tblSubtest { get; set; }
        public virtual ICollection<tblChallenge> tblChallenges { get; set; }
        public virtual ICollection<tblQuestion> tblQuestions { get; set; }
        public virtual ICollection<tblStructContent> tblStructContents { get; set; }
    }
}
