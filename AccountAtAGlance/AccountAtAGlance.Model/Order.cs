using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAtAGlance.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int NumberOfShares { get; set; }
        public decimal Price { get; set; }
        public int OrderTypeId { get; set; }
        public int SecurityId { get; set; }
        public int BrokerageAccountId { get; set; }
    }
}
