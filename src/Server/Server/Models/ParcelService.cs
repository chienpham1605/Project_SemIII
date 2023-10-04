using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ParcelService
    {
        public ParcelService()
        {
            ParcelOrders = new HashSet<ParcelOrder>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ServiceDescription { get; set; } = null!;
        public string ServiceStatus { get; set; } = null!;
        public int TimeConsuming { get; set; }

        public virtual ServicePrice? ServicePrice { get; set; }
        public virtual ICollection<ParcelOrder> ParcelOrders { get; set; }
    }
}
