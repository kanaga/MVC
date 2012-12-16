using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Repository
{
    public class PromotionRule
    {

        public int Id { get; set; }
        public int PromTypeId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string PromoExclusion { get; set; }
        public string Message { get; set; }

        public List<PromotionType> PromotionTypes { get; set; }
        public virtual MainPromo MainPromo { get; set; }



    }
}
