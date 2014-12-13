using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EUTmvc.Models.Admin
{
    public class AdminSubtestModel
    {
        static EUTContext db = new EUTContext();
        public static List<AdminSubTestIndexAction> ViewSubtest()
        {
            var dataSubtest = db.tblSubtests;
            List<AdminSubTestIndexAction> subtest = new List<AdminSubTestIndexAction>();
            foreach (var item in dataSubtest)
            {
                var e = new AdminSubTestIndexAction();
                e.Id = item.Id;
                e.Name = item.Name;
                e.Time = item.Time;
                e.QuestionNumber = item.QuestionNumber;
                e.Description = item.Description;
                subtest.Add(e);
            }
            return subtest;
        }

        public static AdminSubTestEditAction EditViewSubtest(int Id)
        {
            var dataSubtest = db.tblSubtests.Find(Id);
            var e = new AdminSubTestEditAction
            {
                Id = dataSubtest.Id,
                Name = dataSubtest.Name,
                Time = dataSubtest.Time,
                QuestionNumber = dataSubtest.QuestionNumber,
                Description = dataSubtest.Description
            };
            return e;
        }

        public static void EditSubmitSubtest(AdminSubTestEditAction model)
        {
            var dataSubtest = db.tblSubtests.Find(model.Id);
            dataSubtest.Name = model.Name;
            dataSubtest.Time = model.Time;
            dataSubtest.QuestionNumber = model.QuestionNumber;
            dataSubtest.Description = model.Description;
            db.SaveChanges();
        }

        public static void NewSubmitSubtest(AdminSubTestNewAction model)
        {
            tblSubtest subtest = new tblSubtest
            {   
                Code = model.Name,
                Name = model.Name,
                Time = model.Time,
                QuestionNumber = model.QuestionNumber,
                Description = model.Description
            };
            db.tblSubtests.Add(subtest);
            db.SaveChanges();
        }

        public static AdminSubTestDeleteAction DeleteViewSubtest(int id)
        {
            var dataSubtest = db.tblSubtests.Find(id);
            var e = new AdminSubTestDeleteAction
            {
                Id = dataSubtest.Id,
                Name = dataSubtest.Name,
                Time = dataSubtest.Time,
                QuestionNumber = dataSubtest.QuestionNumber,
                Description = dataSubtest.Description
            };
            return e;
        }

        public static bool DeleteSubmitSubtest(AdminSubTestDeleteAction model)
        {
            bool ok = false;
            var dataDelete = db.tblSubtests.Find(model.Id);
            try
            {
                db.tblSubtests.Remove(dataDelete);
                db.SaveChanges();
                ok = true;
            }
            catch{}
            return ok;
        }
    }

    public class AdminSubTestIndexAction
    {
        public int Id { get; set; }

        [Display(Name = "Môn thi")]
        public string Name { get; set; }

        [Display(Name = "Thời gian")]
        public int Time { get; set; }

        [Display(Name = "Câu hỏi")]
        public int QuestionNumber { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class AdminSubTestEditAction
    {
        public int Id { get; set; }

        [Display(Name = "Môn thi")]
        [Required(ErrorMessage = "Bạn chưa nhập môn thi!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "Bạn chưa nhập thời gian thi!", AllowEmptyStrings = false)]
        public int Time { get; set; }

        [Display(Name = "Câu hỏi")]
        [Required(ErrorMessage = "Bạn chưa nhập số câu hỏi", AllowEmptyStrings = false)]
        public int QuestionNumber { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class AdminSubTestNewAction
    {
        public int Id { get; set; }

        [Display(Name = "Môn thi")]
        [Required(ErrorMessage = "Bạn chưa nhập môn thi!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "Bạn chưa nhập thời gian thi!", AllowEmptyStrings = false)]
        public int Time { get; set; }

        [Display(Name = "Câu hỏi")]
        [Required(ErrorMessage = "Bạn chưa nhập số câu hỏi", AllowEmptyStrings = false)]
        public int QuestionNumber { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
    public class AdminSubTestDeleteAction
    {
        public int Id { get; set; }

        [Display(Name = "Môn thi")]
        public string Name { get; set; }

        [Display(Name = "Thời gian")]
        public int Time { get; set; }

        [Display(Name = "Câu hỏi")]
        public int QuestionNumber { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}