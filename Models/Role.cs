using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{
    public class Role
    {
        [Display(Name = "Id")]
        public int RoleId {  get; set; }
        [Required(ErrorMessage = "Role name required")]
        public string Name { get; set; }
    }
}