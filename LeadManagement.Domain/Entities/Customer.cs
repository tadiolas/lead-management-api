using LeadManagement.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LeadManagement.Domain.Entities
{
    public class Customer : IBaseEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; private set; }

        [Required]
        public string Suburb { get; private set; }

        public AdditionalContact AdditionalContact { get; private set; }

        [JsonConstructor]
        public Customer(string firstName, string suburb)
        {
            FirstName = firstName;
            Suburb = suburb;

            ValidateFieldsThrowIfInvalid();
        }

        public void ValidateFieldsThrowIfInvalid()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Suburb))
            {
                throw new ArgumentNullException();
            }
        }

        public void SetAdditionalContact(AdditionalContact additionalContact)
        {
            AdditionalContact = additionalContact;
        }
    }
}
