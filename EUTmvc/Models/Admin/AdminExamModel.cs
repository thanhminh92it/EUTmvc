using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EUTmvc.Utils;
using Microsoft.Office.Interop.Word;

namespace EUTmvc.Models.Admin
{
    public class AdminExamModel
    {
        static EUTContext db = new EUTContext();
        public static List<AdminExamIndexAction> ViewExam()
        {
            var dataExam = db.tblExamQuestions;
            List<AdminExamIndexAction> exam = new List<AdminExamIndexAction>();
            foreach (var item in dataExam)
            {
                var e = new AdminExamIndexAction();
                e.Id = item.Id;
                e.Subtest = item.tblStruct.tblSubtest.Name;
                e.Description = item.Description;
                e.CreateDate = item.CreatedDate == null ? null : String.Format("{0:dd/MM/yyyy}", item.CreatedDate);
                e.CreateBy = item.CreatedBy;
                exam.Add(e);
            }
            return exam;
        }

        public static void AddExam(AdminExamAddAction model)
        {
            var examQuestion = new tblExamQuestion();
            examQuestion.StructId = 1;
            db.tblExamQuestions.Add(examQuestion);
            db.SaveChanges();
            int id = examQuestion.Id;
            string strQ = "";
            string strA = "";
            string fileNameQ = "DeThi" + id;
            string fileNameA = "DapAn" + id;
            if (Uploader.HasFile(model.fileQuestion))
            {
                strQ = Uploader.SaveWord(model.fileQuestion, "~/Uploads/file/", fileNameQ + ".docx");
            }
            //return null;
            Application application = new Application();
            Document document = application.Documents.Open(strQ + fileNameQ + ".docx");
            // Loop through all words in the document.
            //int count = document.Words.Count;
            string text = "" + document.Words[4].Text;
            text = text.Trim();
            application.Quit();

            StreamReader sr = new StreamReader(strQ + fileNameQ + ".html", Encoding.GetEncoding(1252));
            //StreamWriter sw = new StreamWriter("D:/Doc/De123.txt");

            string html = sr.ReadToEnd();
            sr.Close();

            string str = html;

            string _str = "<div class=WordSection1>";
            int k = html.IndexOf(_str);
            if (k > -1)
            {
                str = html.Substring(k + _str.Length);
            }
            k = str.LastIndexOf("</div>");
            if (k > -1)
            {
                str = str.Substring(0, k);
            }
            str = str.Trim();
            str = ConvertToHtml.StripTagsCharArray(str);
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            var item = new List<string>();
            string str2 = "</p>";
            int l = str2.Length;
            while (str.Length > 0)
            {
                string s = "";
                int j = str.IndexOf(str2);
                s = str.Substring(0, j + l);
                str = str.Substring(j + l);
                str = str.Trim();
                item.Add(s);
            }
            item.RemoveAt(0);
            item.RemoveAt(0);
            
            for (var j = 0; j < item.Count; j++)
            {
                var question = new tblQuestion
                {
                    Code = item.Count.ToString(),
                    Contents = ChuanHoa.ChuanHoaHTML(item[j++]),
                    Answer = "A",
                    AnswerA = ChuanHoa.ChuanHoaHTML(item[j++]),
                    AnswerB = ChuanHoa.ChuanHoaHTML(item[j++]),
                    AnswerC = ChuanHoa.ChuanHoaHTML(item[j++]),
                    AnswerD = ChuanHoa.ChuanHoaHTML(item[j]),
                    CategoryID = 3,
                    FormID = 1
                };
                db.tblQuestions.Add(question);
                db.SaveChanges();
                question.Code = question.Id.ToString();
                db.SaveChanges();
            }
            
            
            }

    }
    public class AdminExamIndexAction
    {
        [Display(Name = "Mã đề thi")]
        public int Id { get; set; }

        [Display(Name = "Môn thi")]
        public string Subtest { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ngày tạo")]
        public string CreateDate { get; set; }

        [Display(Name = "Người tạo")]
        public string CreateBy { get; set; }
    }

    public class AdminExamAddAction
    {
        public int Id { get; set; }
        [Display(Name = "Đề Thi")]
        public HttpPostedFileBase fileQuestion { get; set; }
    }
}