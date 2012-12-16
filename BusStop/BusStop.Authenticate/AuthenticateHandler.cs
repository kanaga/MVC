using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace BusStop.Authenticate
{
    public class AuthenticateHandler:IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }
        public void Handle(IMessage message)
        {
            var token = message.GetHeader("access-token");
            if(token!="BusStop")
            {
                Console.WriteLine("User not Authenticated");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            }
            Console.WriteLine("User Authenticated");
        }
    }
}
