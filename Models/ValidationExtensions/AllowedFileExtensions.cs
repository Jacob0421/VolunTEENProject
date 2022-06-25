using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.Models.ValidationExtensions
{
    public class AllowedFileExtensions : ValidationAttribute
    {

        private readonly string[] _allowedFileExtensions;

        public AllowedFileExtensions(string[] allowedFileExtensions)
        {
            _allowedFileExtensions = allowedFileExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_allowedFileExtensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }


            return ValidationResult.Success;

        }

        public string GetErrorMessage()
        {
            return $"This file type is not allowed.";
        }

    }
}
