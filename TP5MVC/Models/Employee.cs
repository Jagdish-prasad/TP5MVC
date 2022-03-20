using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP5MVC.Models
{
    public class Employee
    { 
        [Key]
        public int Id{ get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }
        public string IsActive { get; set; }
    }
}
