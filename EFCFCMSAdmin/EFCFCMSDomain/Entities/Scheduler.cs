using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCFCMSDomain
{
    public class Scheduler
    {

        public int SchedulerId { get; set; }
        public int BlockId { get; set; }
        public string SchedulerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set;}
        public virtual ICollection<Block> Blocks { get; set; }

    }
}
