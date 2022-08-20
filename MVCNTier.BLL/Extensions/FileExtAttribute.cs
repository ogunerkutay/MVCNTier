using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Extensions
{
    public class FileExtAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            IFormFile file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "jpg", "jpeg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));
                if (!result) return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        private string GetErrorMessage() => "Image format must be jpeg, jpeg or png";
    }
}
