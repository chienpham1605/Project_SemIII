using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Pincode
    {
        public Pincode()
        {
            MoneyOrderReceiverPincodeNavigations = new HashSet<MoneyOrder>();
            MoneyOrderSenderPincodeNavigations = new HashSet<MoneyOrder>();
            OfficeBranches = new HashSet<OfficeBranch>();
            ParcelOrderReceiverPincodeNavigations = new HashSet<ParcelOrder>();
            ParcelOrderSenderPincodeNavigations = new HashSet<ParcelOrder>();
        }

        public string Pincode1 { get; set; } 
        public string CityName { get; set; } 
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<MoneyOrder> MoneyOrderReceiverPincodeNavigations { get; set; }
        public virtual ICollection<MoneyOrder> MoneyOrderSenderPincodeNavigations { get; set; }
        public virtual ICollection<OfficeBranch> OfficeBranches { get; set; }
        public virtual ICollection<ParcelOrder> ParcelOrderReceiverPincodeNavigations { get; set; }
        public virtual ICollection<ParcelOrder> ParcelOrderSenderPincodeNavigations { get; set; }
    }
}
