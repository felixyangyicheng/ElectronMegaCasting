using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting.CustomValidator
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@', '.');
                if (strings.Length > 2 && strings[2].ToUpper() == AllowDomain.ToUpper())
                {
                    return null;
                }
                return new ValidationResult($"Domain must be {AllowDomain}", new[] { validationContext.MemberName });
            }

            return null;

        }
    }
}
