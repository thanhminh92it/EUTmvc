using System.Web.Mvc;
using EUTmvc.Utils;

namespace EUTmvc.Controllers
{
    public class CaptchaController : Controller
    {
        //
        // GET: /Captcha/

        // This action for get Captcha Image
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        // This is for output cache false
        public ActionResult GetCaptcha()
        {
            Captcha captcha = new Captcha();
            this.Session["CapchaImageText"] = captcha.CapchaImageText;
            return captcha.CaptchaImage;
        }

    }
}
