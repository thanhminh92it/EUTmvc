using System.IO;
using System.Linq;
using System.Web.Mvc;
using EUTmvc.Models;
using EUTmvc.Utils;

namespace EUTmvc.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var model = AccountModel.Login(user);
                if (model != null)
                {
                    Session["Account"] = model.Account;
                    Session["LogedUserFullName"] = model.tblPerson.LastName + " " + model.tblPerson.Name;
                    int k = AccountModel.CheckStatusAccount(model.Account);
                    if (k == 1)
                    {
                        return RedirectToAction("AfterLogin", "Account");
                    }
                    return RedirectToAction("CheckStatusAccount", "Account");
                }
                ViewBag.Message = "Tài khoản hoặc mật khẩu không đúng!";
            }
            return View(user);

        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Login", "Account");
        }
        public ActionResult AfterLogin()
        {
            var account = (string)Session["Account"];
            if (account == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if ((string)Session["CapchaImageText"] + "" == model.CaptchaText)
                {
                    var b = AccountModel.Register(model);
                    if (b)
                    {
                        Session["Account"] = model.Account;
                        return RedirectToAction("ConfirmEmail");
                    }
                    ViewBag.Message = "Đăng ký tài khoản thất bại!";
                }
                else
                {
                    ViewBag.Message = "Vui lòng nhập đúng mã CaptCha!";
                }
            }
            return View(model);
        }

        public ActionResult ConfirmEmail()
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            if (k != 2)
            {
                return RedirectToAction("CheckStatusAccount", "Account");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmEmail(ConfirmEmailModel model)
        {
            if (ModelState.IsValid)
            {
                model.Account = (string)Session["Account"] + "";
                if (model.Account == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var b = AccountModel.ConfirmEmail(model);
                    if (b)
                    {
                        return RedirectToAction("CheckStatusAccount", "Account");
                    }
                    else
                    {
                        ViewBag.Message = "Mã xác nhận không đúng!";
                    }
                }
            }
            return View();
        }

        public ActionResult ForgotPassword()
        {
            var account = (string)Session["Account"];
            if (account != null)
            {
                return RedirectToAction("CheckStatusAccount", "Account");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var account = (string)Session["Account"];
                if (account != null)
                {
                    return RedirectToAction("CheckStatusAccount", "Account");
                }
                if ((string)Session["CapchaImageText"] + "" == model.CaptchaText)
                {
                    var s = AccountModel.ForgotPassword(model);
                    ViewBag.Message = s;
                }
                else
                {
                    ViewBag.Message = "Vui lòng nhập đúng mã CaptCha!";
                }
            }
            return View();
        }

        public ActionResult CheckStatusAccount()
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            switch (k)
            {
                case 1:
                    return RedirectToAction("Index", "Home");
                case 2:
                    return RedirectToAction("ConfirmEmail", "Account");
                case 3:
                    return RedirectToAction("AccountInfo", "Account");
                case 4:
                    return RedirectToAction("ChangePassword", "Account");
                //case 5:

                default:
                    return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult AccountInfo()
        {
            //Session["Account"] = "admin";
            var account = (string)Session["Account"];
            if (account == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = AccountModel.AccountInfo(account);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountInfo(AccountInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var account = (string)Session["Account"];
                if (account == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                model.Account = account;
                var s = AccountModel.EditAccountInfo(model);
                ViewBag.Message = s;
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            var account = (string)Session["Account"];
            if (account == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var account = (string)Session["Account"];
                if (account == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                model.Account = account;
                var s = AccountModel.ChangePassWord(model);
                ViewBag.Message = s;
            }
            return View();
        }

        [AllowAnonymous]
        public JsonResult CheckUserName(string account)
        {
            return Json(!AccountModel.CheckUserName(account), JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult CheckEmail(string email)
        {
            return Json(!AccountModel.CheckEmail(email), JsonRequestBehavior.AllowGet);
        }
    }
}
