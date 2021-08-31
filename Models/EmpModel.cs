using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignment.Models
{
    public class EmpModel
    {

        [Display(Name = "Id")]
        public int EmpId {  get; set; }
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name required")] 
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of Birth required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Contact number required")]
        public string Contact { get; set; }
        [Display(Name = "Id")]
        public int RoleId { get; set; }

        internal void Add(EmpModel empModel)
        {
            throw new NotImplementedException();
        }
    }
}