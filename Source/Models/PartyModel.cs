using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

namespace MVC_TestBed.Models
{
    public class PartyModel
    {
        public VE_Parties Party { get; set; }

        public IList<PartyByPerif_Result> TopRegions { get; set; }
        public IList<PartyByPerif_Result> BottomRegions { get; set; }

        public IList<PartyByAge_Result> TopAges { get; set; }
        public IList<PartyByAge_Result> BottomAges { get; set; }
    }
}