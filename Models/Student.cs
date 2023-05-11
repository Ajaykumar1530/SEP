using System;
using System.Collections.Generic;

namespace InterView.Models
{
    public  class Student
    {
     
        public int StudentId { get; set; }
        public string StudentName { get; set; } 
        public string Qualification { get; set; }
        public string Technology { get; set; }
        public int YOP { get; set; }
        public DateTime DateOfTest { get; set; }
        public string StudentEmail { get; set; }
        public long MobileNo { get; set; }
        public string Password { get; set; } 
        public string ConfirmPassword { get; set; } 
        public int? Score { get; set; }

    }
}
