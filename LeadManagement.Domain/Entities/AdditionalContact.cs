using LeadManagement.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace LeadManagement.Domain.Entities
{
    public class AdditionalContact : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public int CustomerId { get; private set; }

        public Customer Costumer { get; private set; }

        [JsonConstructor]
        public AdditionalContact(string fullName, string phoneNumber, string email, int customerId)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            CustomerId = customerId;

            ValidateFieldsThrowIfInvalid();
            ValidateEmailThrowIfInvalid();
            ValidatePhoneThrowIfInvalid();
        }

        public void ValidateFieldsThrowIfInvalid()
        {
            var error = string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Email) || CustomerId <= 0;

            if (error)
            {
                throw new ArgumentNullException("One or more fields are incorret");
            }
        }

        public void ValidateEmailThrowIfInvalid()
        {
            const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var success = Regex.IsMatch(Email, emailRegex, RegexOptions.IgnoreCase);

            if (!success)
            {
                throw new ArgumentNullException("One or more fields are incorret");
            }
        }

        public void ValidatePhoneThrowIfInvalid()
        {
            const string phoneRegex = @"^\+?[1-9]\d{1,14}$";
            var success = Regex.IsMatch(PhoneNumber, phoneRegex, RegexOptions.IgnoreCase);

            if (!success)
            {
                throw new ArgumentNullException("One or more fields are incorret");
            }
        }
    }
}
