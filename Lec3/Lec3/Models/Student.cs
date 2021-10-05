using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lec3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }

        public Double Cgpa { get; set; }
    }
}