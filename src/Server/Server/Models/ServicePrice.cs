using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ServicePrice
    {
        public int Id { get; set; }
        public int ZoneTypeId { get; set; }
        public int ServiceId { get; set; }
        public int ParselType { get; set; }
        public int ScopeWeightId { get; set; }
        public double ServicePrice1 { get; set; }

        public virtual ParcelService IdNavigation { get; set; } = null!;
        public virtual ParcelType ParselTypeNavigation { get; set; } = null!;
        public virtual WeightScope ScopeWeight { get; set; } = null!;
        public virtual ZoneType ZoneType { get; set; } = null!;
    }
}
