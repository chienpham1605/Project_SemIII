using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class OfficeBranch
    {
        public string Id { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Pincode { get; set; } = null!;

        public virtual Pincode PincodeNavigation { get; set; } = null!;
    }
}
