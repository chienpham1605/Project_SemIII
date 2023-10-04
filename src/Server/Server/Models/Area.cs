using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Area
    {
        public Area()
        {
            Pincodes = new HashSet<Pincode>();
        }

        public int Id { get; set; }
        public string AreaName { get; set; } = null!;

        public virtual ICollection<Pincode> Pincodes { get; set; }
    }
}
