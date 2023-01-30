using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string? PersonNumber { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
