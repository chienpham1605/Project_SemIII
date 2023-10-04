using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public  class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        [Key]
        []

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
