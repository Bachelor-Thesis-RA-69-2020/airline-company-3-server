using System.ComponentModel.DataAnnotations;

namespace AirlineCompany3.Models.Domain
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public virtual void Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, context, results, validateAllProperties: true);

            if (!isValid)
            {
                var errorMessage = new System.Text.StringBuilder();
                foreach (var validationResult in results)
                {
                    errorMessage.Append($"Validation: {validationResult.ErrorMessage}; ");
                }

                throw new ArgumentException(errorMessage.ToString());
            }
        }
    }
}