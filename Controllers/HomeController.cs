using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TestBed.Models;

namespace MVC_TestBed.Controllers
{
    public class HomeController : Controller
    {
        Entities _dataModel = new Entities();
        PartyService _partyService = new PartyService();

        public ActionResult Index(int? id)
        {
            if (!Request.IsAjaxRequest())
            {
                ViewBag.TotalVotes = _dataModel.VE_Users.Where(u => u.AgeID > 2 && u.IPExists != true && u.PartyID != null).Count();

                IEnumerable<GetResults_Result> results = _dataModel.GetResults(true, true, true, true).OrderByDescending(x => x.C2014_WeightedEstimate);
                return View(results.ToList());
            }
            else
            {
                var partyModel =  _partyService.GetPartyDetails((int)id);
                return PartialView("Details", partyModel);
            }
        }



        public ActionResult Details(int id)
        {

            return View(_partyService.GetPartyDetails(id));
        }

    }
}
