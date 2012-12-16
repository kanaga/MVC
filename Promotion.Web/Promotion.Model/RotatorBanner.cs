using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Repository
{
    public class RotatorBanner
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public string Banner { get; set; }
        public string Url { get; set; }
        public string BannerTxt { get; set; }
        public string MobileBanner { get; set; }
        public string BannerMap { get; set; }
        public string MobileMap { get; set; }

        public virtual MainPromo MainPromo { get; set; }


    }
}
