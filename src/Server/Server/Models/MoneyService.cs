using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class MoneyService
    {
        public int Id { get; set; }
        public int ZoneTypeId { get; set; }
        public int MoneyScopeId { get; set; }
        public double Fee { get; set; }

        public virtual MoneyScope MoneyScope { get; set; } = null!;
        public virtual ZoneType ZoneType { get; set; } = null!;
    }
}
