using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace BusStop.Contracts
{
    public class PlaceOrder:IMessage
    {
        public Guid Orderid { get; set; }
        public Guid Customerid { get; set; }
        public Guid Productid { get; set; }

    }
}
