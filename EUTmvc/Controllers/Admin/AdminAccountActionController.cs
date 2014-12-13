using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EUTmvc.Models;
using EUTmvc.Models.Admin;
using EUTmvc.Utils;

namespace EUTmvc.Controllers.Admin
{
    public class AdminAccountActionController : Controller
    {
        private EUTContext db;

        public ActionResult Index()
        {
            return PartialView("_Index", AdminAccountModel.Index());
        }

        public ActionResult New()
        {
            AdminAccountNewAction e = new AdminAccountNewAction();
            return PartialView("_New", e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(AdminAccountNewAction model)
        {
            db = new EUTContext();
            if (ModelState.IsValid)
            {
                AdminAccountModel.New(model);
                string url = Url.Action("Index", "AdminAccountAction");
                return Json(new { success = true, url = url });
            }
            return PartialView("_New", model);
        }
        public ActionResult Edit(string account)
        {
            return PartialView("_Edit", AdminAccountModel.ViewEdit(account));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminAccountEditAction editModel)
        {
            db = new EUTContext();
            if (ModelState.IsValid)
            {
                AdminAccountModel.SaveEdit(editModel);
                string url = Url.Action("Index", "AdminAccountAction");
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", editModel);
        }

        public ActionResult Delete(string account)
        {
            return PartialView("_Delete", AdminAccountModel.ViewDelete(account));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AdminAccountDeleteAction deleteModel)
        {
            if (ModelState.IsValid)
            {
                AdminAccountModel.SubmitDelete(deleteModel);
                string url = Url.Action("Index", "AdminAccountAction");
                return Json(new { success = true, url = url });
            }
            return PartialView("_Delete", deleteModel);

        }

        public ActionResult SetPassword(string account)
        {
            return PartialView("_SetPassword", AdminAccountModel.ViewSetPassword(account));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPassword(AdminAccountSetPasswordAction setPassWordModel)
        {
            if (ModelState.IsValid)
            {
                AdminAccountModel.SubmitSetPassword(setPassWordModel);
                string url = Url.Action("Index", "AdminAccountAction");
                return Json(new { success = true, url = url });
            }
            return PartialView("_SetPassword", setPassWordModel);

        }
    }
}
