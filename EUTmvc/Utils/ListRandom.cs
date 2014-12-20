using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EUTmvc.Utils
{
    class ListRandom
    {
        private Random random { get; set; }
        public int seed { get; set; }
        public ListRandom()
        {
            var rd = new Random();
            seed = rd.Next();
            random = new Random(seed);
        }
        public ListRandom(int i)
        {
            seed = i;
            random = new Random(seed);
        }
        public Papers List(Papers papers)
        {
            var list = papers.Questions.ToList();
            var lists = new List<Question>();
            int m = list.Count;
            int n = m;
            for (int i = 0; i < n; i++)
            {
                var x = random.Next(0, m - 1);
                /* tạo đáp án ngẫu nhiên */
                var q = RandomAnswer(list[x]);
                /* truyen gia tri cua phan tu thu x trong mang degoc vao phan tu thu i cua mang demoi*/
                lists.Add(q);
                //giam so phan tu cua a di 1 phan tu
                m--;
                /*truyen phan tu cuoi cung ve cho phan tu vua bi lay di*/
                list[x] = list[m];
            }
            papers.Questions.Clear();
            papers.Questions = lists;
            return papers;
        }

        private Question RandomAnswer(Question question)
        {
            var list = question.Answers.ToList();
            var lists = new List<Answer>();
            int m = list.Count;
            int n = m;
            for (int i = 0; i < n; i++)
            {
                var x = random.Next(0, m - 1);
                var a = list[x];
                a.Code = ((char)(65 + i)).ToString();
                lists.Add(a);
                //giam so phan tu cua a di 1 phan tu
                m--;
                /*truyen phan tu cuoi cung ve cho phan tu vua bi lay di*/
                list[x] = list[m];
            }
            question.Answers.Clear();
            question.Answers = lists;
            return question;
        }
    }
}
