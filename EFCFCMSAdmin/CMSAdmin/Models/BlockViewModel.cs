using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFCFCMSDomain;

namespace CMSAdmin.Models
{
    public class BlockViewModel
    {
        public IEnumerable<Block> Blocks { get; set; }
    }
}