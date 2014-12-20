using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EUTmvc.Models;

namespace EUTmvc.Utils
{
    public class Papers
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? Time { get; set; }
        public string Subtest { get; set; }
        public string Category { get; set; }

        public List<Question> Questions = new List<Question>();
        public int AccumulatedPoints { get; set; }
        public int Point { get; set; }
        public int seed { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string SelectAnswer { get; set; }
        public string TrueAnswer { get; set; }
        public List<Answer> Answers = new List<Answer>();

    }

    public class Answer
    {
        public string Value { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
    }
    public class FormInfo
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? QuestionNumber { get; set; }
        public int? Time { get; set; }
        public double? Request { get; set; }

        public Subtests Subtest { get; set; }
        public Category Category { get; set; }

        public string Account { get; set; }

        public int Point { get; set; }

        public FormInfo()
        {

        }
        public FormInfo(int id)
        {
            Id = id;
            if (Id != null)
            {
                var db = new EUTContext();
                var model = db.tblForms.Find(id);
                if (model != null)
                {
                    Description = model.Description;
                    QuestionNumber = model.QuestionNumber;
                    Time = model.Time;
                    Request = model.Request;
                }
            }
            Subtest = new Subtests();
            Category = new Category();
        }
    }

    public class Category
    {
        [Required(ErrorMessage = "Bạn chưa chọn môn thi!", AllowEmptyStrings = false)]
        public int SelectCategory { get; set; }
        public List<ListItem> Categories(int id)
        {
            var db = new EUTContext();
            var model = db.tblCategories.Where(a => a.SubtestId == id);
            var list = model.ToList();
            //db.Dispose();
            return list.Select(item => new ListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();
        }
    }
    public class Subtests
    {
        [Required(ErrorMessage = "Bạn chưa chọn môn thi!", AllowEmptyStrings = false)]
        public int SelectSubtest { get; set; }
        public List<ListItem> subtests
        {
            get
            {
                var db = new EUTContext();
                var list = db.tblSubtests.ToList();
                db.Dispose();
                return list.Select(item => new ListItem() { Value = item.Id.ToString(), Text = item.Name }).ToList();
            }
        }
    }

}