using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRVTextToImage;

namespace EUTmvc.Utils
{
    public class Captcha
    {
        public readonly string CapchaImageText;
        public readonly FileStreamResult CaptchaImage;

        public Captcha()
        {
            var CI = new CaptchaRandomImage();
            CapchaImageText = CI.GetRandomString(5);
            // CI.GenerateImage(this.Session["CapchaImageText"].ToString(),300,75);
            // Or We can use another one for get custom color Captcha Image
            CI.GenerateImage(CapchaImageText, 220, 32, Color.DarkGray, Color.White);
            var stream = new MemoryStream();
            CI.Image.Save(stream, ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);
            CaptchaImage = new FileStreamResult(stream, "image/png");
        }
    }
}