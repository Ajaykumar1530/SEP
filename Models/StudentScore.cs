using System;
using System.Collections.Generic;

namespace InterView.Models
{
    public partial class StudentScore
    {
        public int TestId { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
