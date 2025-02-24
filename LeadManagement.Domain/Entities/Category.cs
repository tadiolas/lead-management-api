using LeadManagement.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LeadManagement.Domain.Entities
{
    public class Category : IBaseEntity
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        public string Code { get; private set; }

        [Required]
        public string Description { get; private set; }


        [JsonConstructor]
        public Category(string code, string description)
        {
            Code = code;
            Description = description;
            ValidateFieldsThrowIfInvalid();
        }

        public void ValidateFieldsThrowIfInvalid()
        {
            var error = string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Description);

            if (error)
            {
                throw new ArgumentNullException("One or more fields are incorret");
            }
        }
    }
}
