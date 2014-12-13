using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EUTmvc.Models.Admin
{
    public class AdminNewsModel
    {
        static EUTContext db = new EUTContext();
        public static List<AdminNewsViewAction> ViewNews()
        {
            var dataNew = db.tblNews;
            List<AdminNewsViewAction> anm = new List<AdminNewsViewAction>();
            foreach (var item in dataNew)
            {
                string CreateDate = null;
                if (item.CreatedDate != null)
                    CreateDate = string.Format("{0:dd/MM/yyyy}", item.CreatedDate);
                var wn = new AdminNewsViewAction();
                wn.Id = item.Id;
                wn.Title = item.Title;
                wn.News = item.News;
                wn.CreateBy = item.CreatedBy;
                wn.CreateDate = CreateDate;
                anm.Add(wn);
            }
            return anm;
        }

        public static void NewNews(AdminNewsNewAction model)
        {
            var tintuc = new tblNew
            {
                Title = model.Title,
                News = model.News,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            };
            db.tblNews.Add(tintuc);
            db.SaveChanges();
        }

        public static AdminNewsEditAction EditViewNews(int id)
        {
            var dataNews = db.tblNews.Find(id);
            var e = new AdminNewsEditAction
            {
                Id = dataNews.Id,
                Title = dataNews.Title,
                News = dataNews.News,
            };
            return e;
        }

        public static void EditSaveNews(AdminNewsEditAction model)
        {
            var dataNews = db.tblNews.Find(model.Id);
            int mc = 0;
            if (dataNews.ModifiedCount != null)
                mc = (int)dataNews.ModifiedCount;
            dataNews.Title = model.Title;
            dataNews.News = model.News;
            dataNews.ModifiedBy = "Admin";
            dataNews.ModifiedDate = DateTime.Now;
            dataNews.ModifiedCount = mc + 1;
            db.SaveChanges();
        }

        public static void DeleteNews(int id)
        {
            var a = db.tblNews.Find(id);
            db.tblNews.Remove(a);
            db.SaveChanges();
        }

    }
    public class AdminNewsViewAction
    {
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string News { get; set; }

        [Display(Name = "Ngày tạo")]
        public string CreateDate { get; set; }

        [Display(Name = "Người tạo")]
        public string CreateBy { get; set; }

    }
    public class AdminNewsEditAction
    {
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề bài viết!", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung bài viết!", AllowEmptyStrings = false)]
        public string News { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedCount { get; set; }
    }
    public class AdminNewsNewAction
    {
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề bài viết!", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung bài viết!", AllowEmptyStrings = false)]
        public string News { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
    }
}