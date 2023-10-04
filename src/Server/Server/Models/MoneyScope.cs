using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class MoneyScope
    {
        public MoneyScope()
        {
            MoneyServices = new HashSet<MoneyService>();
        }

        public int Id { get; set; }
        public double MinValue { get; set; }
        public double? MaxValue { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<MoneyService> MoneyServices { get; set; }
    }
}
