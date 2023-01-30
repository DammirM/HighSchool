using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class staff
    {
        public staff()
        {
            PrincipleAdmins = new HashSet<PrincipleAdmin>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<PrincipleAdmin> PrincipleAdmins { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
