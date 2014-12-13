using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EUTmvc.Models
{
    public class NewsModel
    {
        static EUTContext db = new EUTContext();

        public static List<tblNew> News()
        {
            var m = db.tblNews.ToList();
            return m;
        }

        public static tblNew News(int id)
        {
            var m = db.tblNews.Find(id);
            return m;
        }
    }
}