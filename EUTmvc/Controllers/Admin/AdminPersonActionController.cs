using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models.Admin;

namespace EUTmvc.Controllers.Admin
{
    public class AdminPersonActionController : Controller
    {
        //
        // GET: /AdminPersonAction/

        public ActionResult Index()
        {
            return PartialView("_Index", AdminPersonModel.IndexPerson());
        }

        //
        //Edit Person
        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", AdminPersonModel.ViewEdit(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminPersonEditAction editModel)
        {
            if (ModelState.IsValid)
            {
                AdminPersonModel.SaveEdit(editModel);
                string url = Url.Action("Index", "AdminPersonAction");
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", editModel);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", AdminPersonModel.ViewDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AdminPersonDeleteAction deleteModel)
        {
            if (ModelState.IsValid)
            {
                AdminPersonModel.SubmitDelete(deleteModel);
                string url = Url.Action("Index", "AdminPersonAction");
                return Json(new { success = true, url = url });
            }
            return PartialView("_Delete", deleteModel);

        }
    }
}
