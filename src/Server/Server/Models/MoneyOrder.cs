using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class MoneyOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SenderName { get; set; } = null!;
        public string SenderPincode { get; set; } = null!;
        public string SenderPhone { get; set; } = null!;
        public string SenderAddress { get; set; } = null!;
        public string ReceiverName { get; set; } = null!;
        public string ReceiverPincode { get; set; } = null!;
        public string ReceiverPhone { get; set; } = null!;
        public string ReceiverAddress { get; set; } = null!;
        public double TransferValue { get; set; }
        public double TransferFee { get; set; }
        public double Total { get; set; }
        public string? Note { get; set; }
        public byte[] TransferDate { get; set; } = null!;
        public string TransferStatus { get; set; } = null!;
        public string SenderNationalIdentityNumber { get; set; } = null!;
        public string ReceiverNationalIdentityNumber { get; set; } = null!;

        public virtual Pincode ReceiverPincodeNavigation { get; set; } = null!;
        public virtual Pincode SenderPincodeNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
