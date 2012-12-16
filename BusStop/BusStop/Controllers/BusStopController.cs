using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BusStop.Contracts;
using NServiceBus;

namespace BusStop.Controllers
{
    public class BusStopController : ApiController
    {
       
        public Guid Get()
        {
            var order = new PlaceOrder
            {
                Orderid=Guid.NewGuid(),
                Customerid=Guid.NewGuid(),
                Productid=Guid.NewGuid(),
            };
            order.SetHeader("access-token",HttpContext.Current.Request.Params["access-token"]);
            WebApiApplication.Bus.Send(order);
            return order.Orderid;

        }
    }
}
