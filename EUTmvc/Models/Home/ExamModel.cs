using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EUTmvc.Utils;

namespace EUTmvc.Models.Home
{
    public class ExamModel
    {
        public tblForm LoadForm(int id)
        {
            var db = new EUTContext();
            var model = db.tblForms.Find(id);
            db.Dispose();
            return model;
        }
        public Papers BanDamKhong(int id)
        {
            var p = new Papers();
            var db = new EUTContext();
            var model = db.tblExamStructs.FirstOrDefault(a => a.FormId == 4 && a.CategoryNumber == 1);
            if (model != null)
            {

            }
            return null;
        }

        public int Begin(FormInfo formInfo)
        {
            var db = new EUTContext();
            var q = db.tblStructContents.FirstOrDefault(a => a.CategoryId == formInfo.Category.SelectCategory && a.tblExamStruct.FormId == formInfo.Id);
            int ExamStructId = 0;
            int ExamQuestionId = 0;
            if (q != null)
            {
                ExamStructId = q.ExamStructId;
            }
            var question = db.tblExamQuestions.FirstOrDefault(a => a.ExamStructId == ExamStructId);
            if (question != null)
            {
                ExamQuestionId = question.Id;
            }
            var c = new tblChallenge
            {
                AccountId = AccountModel.AccountId(formInfo.Account),
                AccumulatedPoints = formInfo.Point,
                CategoryId = formInfo.Category.SelectCategory,
                ExamQuestionId = ExamQuestionId,
                CreatedBy = formInfo.Account,
                CreatedDate = DateTime.Now
            };
            db.tblChallenges.Add(c);
            db.SaveChanges();
            db.Dispose();
            return ExamQuestionId;
        }

        public bool CheckPoint(FormInfo formInfo)
        {
            var a = AccountModel.AccountInfo(formInfo.Account);
            if (a != null)
            {
                if (a.AccumulatedPoints > formInfo.Point)
                {
                    return true;
                }
            }
            return false;
        }

        public static Papers LoadPapers(int id)
        {
            var db = new EUTContext();
            var examQuestions = db.tblExamQuestions.Find(id);
            if (examQuestions != null)
            {
                var papers = new Papers()
                {
                    Id = id,
                    Time = examQuestions.tblExamStruct.Time,
                    Subtest = examQuestions.tblExamStruct.tblSubtest.Name
                };
                var str = examQuestions.QuestionId.Split(';');
                foreach (var s in str)
                {
                    var q = db.tblQuestions.Find(int.Parse(s));
                    papers.Questions.Add(LoadQuestion(q));
                }
                var listRandom = new ListRandom();
                papers = listRandom.List(papers);
                papers.seed = listRandom.seed;
                return papers;
            }
            return null;
        }

        public static Question LoadQuestion(tblQuestion q)
        {
            if (q != null)
            {
                var question = new Question()
                {
                    Id = q.Id,
                    Text = q.Contents,
                    TrueAnswer = q.Answer
                };
                question.Answers.Add(new Answer() { Value = "A", Text = q.AnswerA });
                question.Answers.Add(new Answer() { Value = "B", Text = q.AnswerB });
                question.Answers.Add(new Answer() { Value = "C", Text = q.AnswerC });
                question.Answers.Add(new Answer() { Value = "D", Text = q.AnswerD });
                return question;
            }
            return null;
        }
    }


}