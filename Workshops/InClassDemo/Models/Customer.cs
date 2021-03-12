using CustomerPortal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InClassDemo.Models
{
    public class Customer
    {

        public Customer()
        {
            this.Province = "Nova Scotia";
        }

        [Required]
        public string Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }


        public string Addrses1 { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        [Required]
        [PostalValidate]
        public string Postal { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        // This property will hold all available states for selection
   //     public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> provinces { get; set; }




    }
}
