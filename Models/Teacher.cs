using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string? PersonNumber { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public int Phone { get; set; }
        public int StaffId { get; set; }

        public virtual staff Staff { get; set; } = null!;
    }
}
