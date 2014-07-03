using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Objects;

namespace MVC_TestBed.Models
{
    public class PartyService
    {

        public PartyModel GetPartyDetails(int id)
        {

            using (var context = new Entities())
            {

                IList<PartyByAge_Result> ageResults = context.PartyByAge((int)id).ToList();
                IList<PartyByPerif_Result> perifResults = context.PartyByPerif((int)id).ToList();

                PartyModel retVal = new PartyModel();
                retVal.Party = context.VE_Parties.Where(p => p.ID == id).FirstOrDefault();
                retVal.TopAges = ageResults.OrderByDescending(r => r.Ψήφοι).Take(5).ToList();
                retVal.BottomAges = ageResults.OrderBy(r => r.Ψήφοι).Take(5).ToList();
                retVal.TopRegions = perifResults.OrderByDescending(r => r.Ψήφοι).Take(5).ToList();
                retVal.BottomRegions = perifResults.OrderBy(r => r.Ψήφοι).Take(5).ToList();
                return retVal;

            }


        }

    }
}