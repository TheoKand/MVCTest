using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace MVC_TestBed.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FutureDateService : IFutureDateService
    {
        public string GetDayName(FutureDate date)
        {
            //uncomment this to test if the full error message is returned to the client call
            //throw new Exception("An unknown catastrophic failure occured");

            DateTime dt = new DateTime(date.Year, date.Month, date.Day);
            return dt.DayOfWeek.ToString();
        }
    }

}
