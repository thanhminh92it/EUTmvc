using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models.Admin;

namespace EUTmvc.Controllers.Admin
{
    public class AdminSubtestActionController : Controller
    {
        //
        // GET: /AdminSubtestAction/

        public ActionResult Index()
        {
            return PartialView("_Index", AdminSubtestModel.ViewSubtest().ToList());
        }

        //
        //Edit Person
        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", AdminSubtestModel.EditViewSubtest(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminSubTestEditAction editModel)
        {
            if (ModelState.IsValid)
            {
                AdminSubtestModel.EditSubmitSubtest(editModel);
                string url = Url.Action("Index", "AdminSubtestAction");
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", editModel);
        }


        //
        //New Person
        public ActionResult New()
        {
            return PartialView("_New");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(AdminSubTestNewAction newModel)
        {
            if (ModelState.IsValid)
            {
                AdminSubtestModel.NewSubmitSubtest(newModel);
                string url = Url.Action("Index", "AdminSubtestAction");
                return Json(new { success = true, url = url });
            }

            return PartialView("_New", newModel);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", AdminSubtestModel.DeleteViewSubtest(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AdminSubTestDeleteAction deleteModel)
        {
            if (ModelState.IsValid)
            {
                var kt = AdminSubtestModel.DeleteSubmitSubtest(deleteModel);
                if (kt)
                {
                    string url = Url.Action("Index", "AdminSubtestAction");
                    return Json(new { success = true, url = url });
                }
                else
                {
                    ViewBag.Message = "Bạn không thể xoá môn này!";
                }
                
            }
            return PartialView("_Delete", deleteModel);
        }

    }
}
