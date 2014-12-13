using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace EUTmvc.Models
{
    public class Subtests
    {
        [Required(ErrorMessage = "Bạn chưa chọn môn thi!", AllowEmptyStrings = false)]
        public int SelectSubtests { get; set; }
        public List<tblSubtest> subtests
        {
            get
            {
                EUTContext db = new EUTContext();
                return db.tblSubtests.ToList();
            }
        }
    }

    public class Category
    {
        public List<ListItem> Categories(int id)
        {
            var db = new EUTContext();
            var model = db.tblCategories.Where(a => a.SubtestsID == id);
            var list = model.ToList();
            return list.Select(item => new ListItem() { Value = item.Id.ToString(), Text = item.Name }).ToList();
        }
    }

    public class Learn
    {
        [Required(ErrorMessage = "Bạn chưa chọn môn thi!", AllowEmptyStrings = false)]
        public int SelectSubtest { get; set; }
        public List<ListItem> Subtests
        {
            get
            {
                var db = new EUTContext();
                var list = db.tblSubtests.ToList();
                return list.Select(item => new ListItem() {Value = item.Id.ToString(), Text = item.Name}).ToList();
            }
        }
        public int SelectCategory { get; set; }
    }

    public class Learning
    {
        public static Evaluation LoadEvaluation(Learn learn)
        {
            var db = new EUTContext();
            var evaluation = new Evaluation();
            var t = db.tblCategories.FirstOrDefault(a => a.Id == learn.SelectCategory && a.SubtestsID==learn.SelectSubtest);
            if (t != null)
            {
                var model = db.tblQuestions.Where(a => a.CategoryID == t.Id);
                int i = 1;
                foreach (var m in model)
                {
                    var q = new Question
                    {
                        ID = m.Id,
                        TheNumber = i++,
                        QuestionText = m.Contents
                    };
                    q.Answers.Add(new Answer { ID = 1, code = "A", AnswerText = m.AnswerA });
                    q.Answers.Add(new Answer { ID = 2, code = "B", AnswerText = m.AnswerB });
                    q.Answers.Add(new Answer { ID = 3, code = "C", AnswerText = m.AnswerC });
                    q.Answers.Add(new Answer { ID = 4, code = "D", AnswerText = m.AnswerD });
                    evaluation.Questions.Add(q);
                }
                evaluation.Subtests = t.tblSubtest.Name;
                evaluation.Category = t.Name;
            }
            return evaluation;
        }

        public static Evaluation LearnResult(Evaluation eval)
        {
            var db = new EUTContext();
            var evaluation = eval;
            int i = 1;
            foreach (var item in evaluation.Questions)
            {
                var m = db.tblQuestions.FirstOrDefault(a => a.Id == item.ID);
                item.TheNumber = i++;
                item.QuestionText = m.Contents;
                item.TrueAnswer = m.Answer;
                item.Answers.Add(new Answer { ID = 1, code = "A", AnswerText = m.AnswerA });
                item.Answers.Add(new Answer { ID = 2, code = "B", AnswerText = m.AnswerB });
                item.Answers.Add(new Answer { ID = 3, code = "C", AnswerText = m.AnswerC });
                item.Answers.Add(new Answer { ID = 4, code = "D", AnswerText = m.AnswerD });
            }
            return evaluation;
        }
    }
    public class Question
    {
        public int ID { set; get; }
        public string QuestionText { set; get; }
        public Nullable<int> TheNumber { get; set; }
        public List<Answer> Answers { set; get; }
        public string SelectedAnswer { set; get; }
        public string TrueAnswer { set; get; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
    public class Answer
    {
        public int ID { set; get; }
        public string code { get; set; }
        public string AnswerText { set; get; }
    }
    public class Evaluation
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public int ExamQuestionId { get; set; }
        public string Subtests { get; set; }
        public string Category { get; set; }
        public int Time { get; set; }
        public int QuestionNumber { get; set; }
        public List<Question> Questions { set; get; }
        public Evaluation()
        {
            Questions = new List<Question>();

        }
    }
    public class Exam
    {
        public static Evaluation LoadEvaluation(int id, string account)
        {
            EUTContext db = new EUTContext();
            var evaluation = new Evaluation();
            var t = db.tblTestResults.FirstOrDefault(a => a.Id == id && a.Account.Equals(account));
            if (t != null)
            {
                var model = db.tblExamStructs.Where(a => a.ExamQuestionId == t.ExamQuestionId);
                foreach (var m in model)
                {
                    var q = new Question
                    {
                        ID = m.QuestionId,
                        TheNumber = m.TheNumber,
                        QuestionText = m.tblQuestion.Contents
                    };
                    q.Answers.Add(new Answer { ID = 1, code = "A", AnswerText = m.tblQuestion.AnswerA });
                    q.Answers.Add(new Answer { ID = 2, code = "B", AnswerText = m.tblQuestion.AnswerB });
                    q.Answers.Add(new Answer { ID = 3, code = "C", AnswerText = m.tblQuestion.AnswerC });
                    q.Answers.Add(new Answer { ID = 4, code = "D", AnswerText = m.tblQuestion.AnswerD });
                    evaluation.Questions.Add(q);
                }
                var model1 = db.tblExamQuestions.Find(t.ExamQuestionId);
                evaluation.ID = t.Id;
                evaluation.ExamQuestionId = t.ExamQuestionId;
                evaluation.QuestionNumber = model1.tblStruct.tblSubtest.QuestionNumber;
                evaluation.Subtests = model1.tblStruct.tblSubtest.Name;
                evaluation.Time = model1.tblStruct.tblSubtest.Time;
                t.ExecutionTime = DateTime.Now;
                db.SaveChanges();
            }
            return evaluation;
        }

        public static bool checkAnswers(int questionId, string answers)
        {
            EUTContext db = new EUTContext();
            var m = db.tblQuestions.FirstOrDefault(a => a.Id == questionId && a.Answer == answers);
            if (m != null) return true;
            return false;
        }

        // Chấm điểm
        public static double Grading(Evaluation evaluation)
        {
            EUTContext db = new EUTContext();
            var model =
                db.tblTestResults.FirstOrDefault(a => a.Id == evaluation.ID && a.Account.Equals(evaluation.Account));
            if (model != null)
            {
                int t = evaluation.Questions.Count;
                int k = evaluation.Questions.Count(m => checkAnswers(m.ID, m.SelectedAnswer));
                foreach (var item in evaluation.Questions)
                {
                    if (item.SelectedAnswer != null)
                    {
                        var testResultsContent = new tblTestResultsContent()
                        {
                            TestResultId = model.Id,
                            ExamStructId = item.ID,
                            Answers = item.SelectedAnswer
                        };
                        db.tblTestResultsContents.Add(testResultsContent);
                        db.SaveChanges();
                    }
                }
                double point = (double)k / t * 10;
                model.Point = point;
                model.EndTime = DateTime.Now;
                db.SaveChanges();
                return point;
            }
            return 0;
        }

        public static int BeginExam(int id, string account)
        {
            EUTContext db = new EUTContext();
            var model = db.tblExamQuestions.Where(m => m.tblStruct.SubtestsId == id).OrderBy(m => Guid.NewGuid()).Take(1);
            int k = Enumerable.FirstOrDefault(model.Select(m => m.Id));
            if (k != 0)
            {
                var testResult = new tblTestResult()
                {
                    Code = account,
                    Account = account,
                    ExamQuestionId = k,
                    CreatedBy = account,
                    CreatedDate = DateTime.Now
                };
                db.tblTestResults.Add(testResult);
                db.SaveChanges();
                testResult.Code = testResult.Id.ToString();
                db.SaveChanges();
                return testResult.Id;
            }
            return 0;
        }

        public static Evaluation ViewTestResult(int id, string account)
        {
            var db = new EUTContext();
            var t = db.tblTestResults.FirstOrDefault(a => a.Id == id && a.Account.Equals(account));
            var evaluation = new Evaluation();
            if (t != null)
            {
                var model = t.tblExamQuestion.tblStruct.tblSubtest;
                evaluation.QuestionNumber = model.QuestionNumber;
                evaluation.Subtests = model.Name;
                evaluation.Time = model.Time;
                evaluation.ExamQuestionId = t.ExamQuestionId;
                var model1 = db.tblExamStructs.Where(a => a.ExamQuestionId == t.ExamQuestionId);
                foreach (var item in model1)
                {
                    var q = new Question
                    {
                        ID = item.QuestionId,
                        TheNumber = item.TheNumber,
                        QuestionText = item.tblQuestion.Contents,
                        TrueAnswer = item.tblQuestion.Answer
                    };
                    var model2 =
                        db.tblTestResultsContents.FirstOrDefault(
                            a => a.TestResultId == t.Id && a.ExamStructId == item.Id);
                    if (model2 != null)
                    {
                        q.SelectedAnswer = model2.Answers;
                        //q.QuestionText = model2.Id +"."+ model2.Answers;
                    }
                    q.Answers.Add(new Answer { ID = 1, code = "A", AnswerText = item.tblQuestion.AnswerA });
                    q.Answers.Add(new Answer { ID = 2, code = "B", AnswerText = item.tblQuestion.AnswerB });
                    q.Answers.Add(new Answer { ID = 3, code = "C", AnswerText = item.tblQuestion.AnswerC });
                    q.Answers.Add(new Answer { ID = 4, code = "D", AnswerText = item.tblQuestion.AnswerD });
                    evaluation.Questions.Add(q);
                }
            }
            return evaluation;
        }
    }

}