using System;
using System.Collections.Generic;

namespace InterView.Models
{
    public partial class CandidatesList
    {
        public int Id { get; set; }
        public string? CandidateName { get; set; }
        public string? Address { get; set; }
        public string? HighestEducationQualification { get; set; }
        public string? GraduationSpecialization { get; set; }
        public int? YearOfGraduation { get; set; }
        public int? CareerGap { get; set; }
        public string? PreferredTechnology { get; set; }
        public long? Mobile { get; set; }
        public string? Email { get; set; }
        public byte[]? Resume { get; set; }
        public byte[]? Image { get; set; }
    }
}
