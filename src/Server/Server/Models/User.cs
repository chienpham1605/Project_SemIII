using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class User
    {
        public User()
        {
            MoneyOrders = new HashSet<MoneyOrder>();
            ParcelOrders = new HashSet<ParcelOrder>();
            TrackHistories = new HashSet<TrackHistory>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressWard { get; set; }
        public string? AddressStreet { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<MoneyOrder> MoneyOrders { get; set; }
        public virtual ICollection<ParcelOrder> ParcelOrders { get; set; }
        public virtual ICollection<TrackHistory> TrackHistories { get; set; }
    }
}
