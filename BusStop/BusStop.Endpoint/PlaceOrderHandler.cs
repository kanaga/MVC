using System;
using BusStop.Contracts;
using NServiceBus;

namespace BusStop.backend
{
    public class PlaceOrderHandler : IMessageHandler<PlaceOrder>
    {
        #region IMessageHandler<PlaceOrder> Members

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order Receive" + message.Orderid);
        }

        #endregion
    }
}