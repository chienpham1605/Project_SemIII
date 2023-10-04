using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class ZoneType
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ZoneDescription { get; set; } = null!;

        public virtual ICollection<MoneyService> MoneyServices { get; set; }
        public virtual ICollection<ServicePrice> ServicePrices { get; set; }  
        public ZoneType()
        {
            MoneyServices = new HashSet<MoneyService>();
            ServicePrices = new HashSet<ServicePrice>();
        }
    }
}
