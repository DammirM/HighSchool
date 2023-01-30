using System;
using System.Collections.Generic;

namespace HighSchool.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int Grade1 { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
    }
}
