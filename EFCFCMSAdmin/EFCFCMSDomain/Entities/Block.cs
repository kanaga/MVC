using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCFCMSDomain
{
    public class Block
    {

        public int BlockId { get; set; }
        public int CompanyId { get; set; }
        public int DivisionId  { get; set; }
        public int PageId { get; set; }
        public string BlockName { get; set; }
        public string BlockContent { get; set; }
        public string HtmlUrl { get; set;}
        public string CssUrl { get; set; }
        


     
    }
}
