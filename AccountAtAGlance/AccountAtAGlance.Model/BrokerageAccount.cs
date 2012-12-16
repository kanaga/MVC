using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAtAGlance.Model
{
    public class BrokerageAccount
    {
        public BrokerageAccount()
        {
            Positions = new HashSet<Position>();
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public decimal Total { get; set; }
        public decimal MarginalBalance { get; set; }
        public bool IsRetirement { get; set; }
        public int CustomerId { get; set; }
        public decimal CashTotal { get; set; }
        public decimal PositionTotal { get; set; }
        public int WatchListId { get; set; }

        public ICollection<Position> Positions { get; set; }
        public ICollection<Order> Orders { get; set; }
        public WatchList WatchLists { get; set; }
    }
}
