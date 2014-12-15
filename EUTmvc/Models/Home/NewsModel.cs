using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EUTmvc.Utils;

namespace EUTmvc.Models
{
    public class NewsModel
    {
        static EUTContext db = new EUTContext();

        public static List<tblNew> News()
        {
            var m = db.tblNews.ToList();
            foreach (var item in m)
            {
                string s = ConvertToHtml.RemoveTagsRegex(item.News);
                item.News = ChuanHoa.ChuoiNkitu(s, 300);
            }
            return m;
        }

        public static tblNew News(int id)
        {
            var m = db.tblNews.Find(id);
            return m;
        }
    }
}