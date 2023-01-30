using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class PrincipleAdmin
    {
        public int Id { get; set; }
        public string? Position { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public int StaffId { get; set; }

        public virtual staff Staff { get; set; } = null!;
    }
}
