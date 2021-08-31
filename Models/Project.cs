using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{
    public class Project
    {
        [Display(Name = "Id")]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Project Name required")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate {  get; set; }
        public int Budget { get; set; }

    }
}