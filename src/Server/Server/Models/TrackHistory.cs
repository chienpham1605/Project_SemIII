using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class TrackHistory
    {
        public int TrackId { get; set; }
        public int OrderId { get; set; }
        public string NewStatus { get; set; } = null!;
        public byte[] UpdateTime { get; set; } = null!;
        public string FromLocation { get; set; } = null!;
        public string NewLocation { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual User Employee { get; set; } = null!;
        public virtual ParcelOrder Order { get; set; } = null!;
    }
}
