using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TestBed.Controllers
{
    public class jQueryAjaxController : Controller
    {

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            List<Person> people = new List<Person>()
            {
                new Person() { Name="Theo", Age=30 },
                new Person() { Name="Marianna",Age=29 }
            };
            ViewBag.People = people;
            
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPerson(string name)
        {
            Person person = (ViewBag.People as List<Person>).FirstOrDefault(p => p.Name == name);

            return PartialView(person);
        }

        public JsonResult GetPersonJson(string name)
        {
            Person person = (ViewBag.People as List<Person>).FirstOrDefault(p => p.Name == name);
            //if you don't specify JsonRequestBehavior.AllowGet the client side can't read this
            return Json(person,JsonRequestBehavior.AllowGet);
        }



    }
}
