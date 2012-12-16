using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Repository
{
    public  class MainPromo
    {
        public MainPromo()
        {
            PromotionRules = new List<PromotionRule>();
            RotatingBanners = new List<RotatorBanner>();
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FooterDisclaimer { get; set; }
        public DateTime CreateDate { get; set; }
        public string HeaderBanner { get; set; }
        public bool Display { get; set; }

        public List<PromotionRule> PromotionRules { get; set; }
        public List<RotatorBanner> RotatingBanners { get; set; }

    }
}
