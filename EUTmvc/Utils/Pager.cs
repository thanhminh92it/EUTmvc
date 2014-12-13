using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EUTmvc.Utils
{
    public class Pager
    {
        /// <summary>
        /// Trang số hiện tại
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// Số bản ghi trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Số trang trên mỗi nhóm
        /// </summary>
        public int GroupSize { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(1.0 * RowCount / PageSize);
            }
        }

        /// <summary>
        /// Trang cuối cùng
        /// </summary>
        public int LastPageNo
        {
            get
            {
                return PageCount - 1;
            }
        }

        /// <summary>
        /// Bản ghi bắt đầu của trang hiện tại
        /// </summary>
        public int StartRow
        {
            get
            {
                return PageNo * PageSize;
            }
        }

        /// <summary>
        /// Nhóm số hiện tại
        /// </summary>
        public int GroupNo
        {
            get
            {
                return PageNo / GroupSize;
            }
        }

        /// <summary>
        /// Tổng số nhóm
        /// </summary>
        public int GroupCount
        {
            get
            {
                return (int)Math.Ceiling(1.0 * PageCount / GroupSize);
            }
        }

        /// <summary>
        /// Nhóm cuối cùng
        /// </summary>
        public int LastGroupNo
        {
            get
            {
                return GroupCount - 1;
            }
        }

        /// <summary>
        /// Trang đầu của nhóm hiện tại
        /// </summary>
        public int StartPageNo
        {
            get
            {
                return GroupNo * GroupSize;
            }
        }

        /// <summary>
        /// Trang cuối của nhóm hiện tại
        /// </summary>
        public int EndPageNo
        {
            get
            {
                if (GroupNo == LastGroupNo)
                {
                    return LastPageNo;
                }
                return StartPageNo + GroupSize - 1;
            }
        }

        /// <summary>
        /// Chuyển đến trang được chọn để hiển thị
        /// </summary>
        private void Navigate()
        {
            foreach (var p in HttpContext.Current.Request.Params.AllKeys)
            {
                if (p != null && p.ToLower().Contains("pageno:"))
                {
                    PageNo = int.Parse(p.Substring(7).Trim());
                }
                if (PageNo < 0)
                {
                    this.PageNo = this.LastPageNo;
                }
                else if (PageNo > this.LastPageNo)
                {
                    this.PageNo = 0;
                }
                else
                {
                    this.PageNo = PageNo;
                }
            }
        }

        /// <summary>
        /// Khởi tạo thông tin phân trang
        /// </summary>
        /// <param name="Id">Định danh phân trang</param>
        /// <param name="PageSize">Số mục trên mỗi trang</param>
        /// <param name="GroupSize">Số trang trên mỗi nhóm</param>
        /// <param name="RowCount">Tổng số bản ghi của tập dữ liệu muốn phân trang</param>
        /// <returns>Đối tượng phân trang</returns>
        public static Pager Set(String Id = "Pager", int PageSize = 10, int GroupSize = 1, int RowCount = 999999)
        {
            var pager = HttpContext.Current.Session[Id] as Pager;
            if (pager == null)
            {
                pager = new Pager
                {
                    PageSize = PageSize,
                    GroupSize = GroupSize,
                    RowCount = RowCount
                };
                HttpContext.Current.Session[Id] = pager;
            }
            if (RowCount != 999999)
            {
                pager.RowCount = RowCount;
            }
            pager.Navigate();
            return pager;
        }

        /// <summary>
        /// Hiển thị thông tin thanh điều hướng
        /// </summary>
        /// <param name="PagerId">Định danh phân trang</param>
        /// <returns>HTML các nút điều hướng phân trang</returns>
        public static MvcHtmlString NavigationBar(String PagerId = "Pager")
        {
            var p = Pager.Set(PagerId);

            String button = "<input type='submit' value='{0}' name='pageno:{1}'/>";
            StringBuilder nav = new StringBuilder("<form class='pager' method='post'>");
            nav.AppendFormat(button, "|<", 0);
            nav.AppendFormat(button, "<", p.PageNo - 1);

            for (int i = p.StartPageNo; i <= p.EndPageNo; i++)
            {
                if (i == p.PageNo)
                {
                    nav.AppendFormat(button, i + 1, i + "' class='selected-page-no");
                }
                else
                {
                    nav.AppendFormat(button, i + 1, i);
                }
            }

            nav.AppendFormat(button, ">", p.PageNo + 1);
            nav.AppendFormat(button, ">|", p.LastPageNo);
            nav.Append("</form>");

            return MvcHtmlString.Create(nav.ToString());
        }
    }
}