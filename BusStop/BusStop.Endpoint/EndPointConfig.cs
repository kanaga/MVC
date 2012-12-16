using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusStop.Authenticate;
using NServiceBus;

namespace BusStop.backend
{
    public class EndPointConfig : IConfigureThisEndpoint, AsA_Server,IWantCustomInitialization,ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            Configure.With()
                .DisableTimeoutManager();

        }

        public void SpecifyOrder(Order order)
        {
            order.Specify<First<AuthenticateHandler>>();
        }
    }
}
