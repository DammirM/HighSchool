using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class Class
    {
        public Class()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string Class1 { get; set; } = null!;

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
