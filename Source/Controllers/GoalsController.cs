using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TestBed.Models;

namespace MVC_TestBed.Controllers
{
    public class GoalsController : Controller
    {
        //
        // GET: /Goal/
        static GoalContext gc;

        public ActionResult Index(string addTeam,string removeTeam)
        {
            try
            {
                if (!Request.IsAjaxRequest())
                {
                    gc = new GoalContext();
                    return View(gc);
                }
                else
                {
                    if (!string.IsNullOrEmpty(addTeam))
                    {
                        gc.CurrentTeams.Add(gc.AllTeams.FirstOrDefault(t => t.Name == addTeam));
                        return PartialView("UsedTeams", gc);
                    }
                    else if (!string.IsNullOrEmpty(removeTeam))
                    {
                        gc.CurrentTeams.Remove(gc.AllTeams.FirstOrDefault(t => t.Name == removeTeam));
                        return PartialView("UsedTeams", gc);
                    }
                    else
                    {
                        return PartialView("UnusedTeams", gc);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return View(gc);
            }
        }

    }
}
