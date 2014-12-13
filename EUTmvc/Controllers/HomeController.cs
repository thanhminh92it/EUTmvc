using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EUTmvc.Models;

namespace EUTmvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            var model = NewsModel.News();
            return View(model);
        }

        public ViewResult News(int id)
        {
            var model = NewsModel.News(id);
            return View(model);
        }
        public ViewResult StateList()
        {
            return View();
        }
        public JsonResult GetJsonData()
        {
            var persons = new List<Person>
                              {
                                  new Person{Id = 1, FirstName = "F1", 
                                      LastName = "L1", 
                                      Addresses = new List<Address>
                                                      {
                                                          new Address{Line1 = "LaneA"},
                                                          new Address{Line1 = "LaneB"}
                                                      }},
                                                                                                        
                                  new Person{Id = 2, FirstName = "F2", 
                                      LastName = "L2", 
                                      Addresses = new List<Address>
                                                      {
                                                          new Address{Line1 = "LaneC"},
                                                          new Address{Line1 = "LaneD"}
                                                      }}};
            var list = new List<ListItem>
               {
                    new ListItem { Value = "1", Text = "VA" },
                    new ListItem { Value = "2", Text = "MD" },
                    new ListItem { Value = "3", Text = "DC" }
               };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
