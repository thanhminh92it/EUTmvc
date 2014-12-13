using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EUTmvc.Models.Admin;

namespace EUTmvc.Controllers.Admin
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.Title = "Quản trị hệ thống Website";
            return View();
        }
        public ActionResult Account()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.Title = "Quản trị hệ thống Website";
            return View();
        }
        public ActionResult Person()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.Title = "Quản lý danh sách người dùng";
            return View();
        }
        public ActionResult News()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.Title = "Quản lý tin tức";
            return View();
        }

        public ActionResult Exam()
        {
            ViewBag.Title = "Quản lý đề thi";
            return View();
        }

        public ActionResult Subtest()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.Title = "Quản lý môn thi";
            return View();
        }

        public ActionResult Question()
        {
            ViewBag.Title = "Quản lý câu hỏi";
            return View();
        }

        public ActionResult Login()
        {
            Session["Username"] = null;
            ViewBag.Title = "Đăng nhập vào hệ thống";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminAccountLogin model)
        {
            ViewBag.Title = "Đăng nhập vào hệ thống";
            if (ModelState.IsValid)
            {
                bool kt = AdminAccountModel.SubmitLogin(model);
                if (kt)
                {
                    Session["Username"] = model.Account;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Message = "Sai tài khoản hoặc mật khẩu!";
                }
            }
            return View(model);
        }
    }
}
