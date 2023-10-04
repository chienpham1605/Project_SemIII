using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class WeightScope
    {
     

        public int Id { get; set; }
        public double MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ServicePrice> ServicePrices { get; set; }   
        public WeightScope()
        {
            ServicePrices = new HashSet<ServicePrice>();
        }
    }
}
