using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }
        public Department Department { get; set; }
    }
}
