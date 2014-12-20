using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EUTmvc.Models.Home
{
    public class ExamStart
    {
        static EUTContext db = new EUTContext();
        public static Exam LoadExam(int id)
        {
            Exam exam = new Exam();
            var dbExamStruct = db.tblExamStructs.Find(id);
            var dbExamQuestion = db.tblExamQuestions.Where(q => q.ExamStructId == id);
            exam.ID = dbExamStruct.Id;
            exam.Code = dbExamStruct.Code;
            exam.Name = dbExamStruct.Name;
            exam.Title = dbExamStruct.Title;
            exam.GradeName = dbExamStruct.tblGrade.Name;
            exam.AllTime = dbExamStruct.AllTime;
            exam.Description = dbExamStruct.Description;
            exam.CreateBy = dbExamStruct.CreatedBy;
            foreach(var item in dbExamQuestion)
            {
                exam.Subtest = item.tblQuestion.tblCategory.tblSubtest.Name;
                var q = new Question();
                q.ID = item.tblQuestion.Id;
                q.Contents = item.tblQuestion.Contents;
                q.Answer = item.tblQuestion.Answer;
                q.AnswerA = item.tblQuestion.AnswerA;
                q.AnswerB = item.tblQuestion.AnswerB;
                q.AnswerC = item.tblQuestion.AnswerC;
                q.AnswerD = item.tblQuestion.AnswerD;
                if (string.IsNullOrEmpty(Convert.ToString(item.tblQuestion.SuggestionId)))
                {
                    q.Suggestion = null;
                }
                else
                {
                    q.Suggestion = item.tblQuestion.tblSuggestion.Description;
                    q.SuggestionID = item.tblQuestion.tblSuggestion.Id;
                }
                exam.ListQuestion.Add(q);
            }
            return exam;
        }
        internal static void LoadExam()
        {
            throw new NotImplementedException();
        }
        public static ExamResult LoadExamResult(string Answer)
        {
            ExamResult a = new ExamResult();
            a.Answer = Answer;
            return a;
        }
    }
    public class Exam
    {   
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<Question> ListQuestion { get; set; }
        public string GradeName { get; set; }
        public int? AllTime { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public string Subtest { get; set; }

        public Exam()
        {
            ListQuestion = new List<Question>();
        }
    }
    public class Question
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public string Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string Suggestion { get; set; }
        public int? SuggestionID { get; set; }
        public string SelectedAnswer { get; set; }
    }
    public class ExamResult
    {
        public string Answer { get; set; }
    }
}