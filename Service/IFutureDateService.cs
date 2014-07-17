using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace MVC_TestBed.Service
{

    [DataContract]
    public class FutureDate
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int Month { get; set; }
        [DataMember]
        public int Day { get; set; }
    }


    [ServiceContract]
    public interface IFutureDateService
    {
        [OperationContract]
        string GetDayName(FutureDate date);
    }
}
