using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ParcelType
    {
        public ParcelType()
        {
            ParcelOrders = new HashSet<ParcelOrder>();
            ServicePrices = new HashSet<ServicePrice>();
        }

        public int Id { get; set; }
        public string ParcelName { get; set; } = null!;
        public double ParcelMaxLength { get; set; }
        public double ParcelMaxWidth { get; set; }
        public double ParcelMaxHeight { get; set; }
        public double ParcelMaxWeight { get; set; }
        public double OverDimensionRate { get; set; }

        public virtual ICollection<ParcelOrder> ParcelOrders { get; set; }
        public virtual ICollection<ServicePrice> ServicePrices { get; set; }
    }
}
