using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EUTmvc.Controllers;
namespace UnitTestEUTmvc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //
            AccountController ac=new AccountController();
            //
            ViewResult result=ac.Login() as ViewResult;
           


        }
    }
}
