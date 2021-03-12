using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomerPortal
{
    class PostalValidate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {

            string str = value.ToString();

            if (!IsUSorCanadianZipCode(str))
            {
                return new ValidationResult("Invalid postal code");
            }
            
            return ValidationResult.Success;
        }

        private bool IsUSorCanadianZipCode(string zipCode)
        {
            bool isValidUsOrCanadianZip = false;
            string pattern = @"^\d{5}-\d{4}|\d{5}|[A-Z]\d[A-Z] \d[A-Z]\d$";
            Regex regex = new Regex(pattern);
            return isValidUsOrCanadianZip = regex.IsMatch(zipCode);
        }

    }


}
