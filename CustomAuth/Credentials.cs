using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuth
{
    public class Credentials : IValidatableObject
    {
        
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //In a real-world app there would be a database validation...
            if(login!="john@doe.com" || password!="myp@ssword")
            {
                yield return new ValidationResult(
                $"Wrong password or login !",
                new[] { nameof(login), nameof(password)});
            }
        }
    }
}
