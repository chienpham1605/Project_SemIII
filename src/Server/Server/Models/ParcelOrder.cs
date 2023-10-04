using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ParcelOrder
    {
        public ParcelOrder()
        {
            TrackHistories = new HashSet<TrackHistory>();
        }

        public int Id { get; set; }
        public byte[] OrderDate { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public string SenderAddress { get; set; } = null!;
        public string SenderPincode { get; set; } = null!;
        public string SenderPhone { get; set; } = null!;
        public string SenderEmail { get; set; } = null!;
        public string ReceiverName { get; set; } = null!;
        public string ReceiverAddress { get; set; } = null!;
        public string ReceiverPincode { get; set; } = null!;
        public string ReceiverPhone { get; set; } = null!;
        public string? ReceiverEmail { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int ParcelTypeId { get; set; }
        public double ParcelHeight { get; set; }
        public double ParcelLenght { get; set; }
        public double ParcelWidth { get; set; }
        public double ParcelWeight { get; set; }
        public double VppValue { get; set; }
        public string? Note { get; set; }
        public string PaymentMode { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public string DeliveryDate { get; set; } = null!;
        public double TotalCharge { get; set; }

        public virtual ParcelType ParcelType { get; set; } = null!;
        public virtual Pincode ReceiverPincodeNavigation { get; set; } = null!;
        public virtual Pincode SenderPincodeNavigation { get; set; } = null!;
        public virtual ParcelService Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
    }
}
