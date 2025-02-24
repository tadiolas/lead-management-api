using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LeadManagement.Domain.Entities
{
    public class Lead : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public double Price { get; private set; }

        [Required]
        public int DiscountPercentage { get; private set; }

        [Required]
        [EnumDataType(typeof(StatusLead))]
        public StatusLead Status { get; private set; }

        [Required]
        public DateTime DateCreated { get; private set; }

        [Required]
        public int CategoryId { get; private set; }

        public Category Category { get; private set; }

        [Required]
        public int CustomerId { get; private set; }

        public Customer Customer { get; private set; }


        [JsonConstructor]
        public Lead(string description, double price, StatusLead status, int categoryId, int customerId)
        {
            Description = description;
            Price = price;
            Status = status;
            CategoryId = categoryId;
            CustomerId = customerId;
            DateCreated = DateTime.Now;

            ValidateFieldsThrowIfInvalid();
            CalculateDiscountPercentage();
        }

        public Lead(Lead lead, Customer customer, Category category)
        {
            Id = lead.Id;
            Description = lead.Description;
            Price = lead.Price;
            DiscountPercentage = lead.DiscountPercentage;
            Status = lead.Status;
            DateCreated = lead.DateCreated;
            CategoryId = lead.CategoryId;
            CustomerId = lead.CustomerId;
            Customer = customer;
            Category = category;

            ValidateFieldsThrowIfInvalid();
            CalculateDiscountPercentage();
        }
        public Lead(Lead lead, Customer customer, Category category, AdditionalContact additionalContact)
        {
            Id = lead.Id;
            Description = lead.Description;
            Price = lead.Price;
            DiscountPercentage = lead.DiscountPercentage;
            Status = lead.Status;
            DateCreated = lead.DateCreated;
            CategoryId = lead.CategoryId;
            CustomerId = lead.CustomerId;
            Customer = customer;
            Customer.SetAdditionalContact(additionalContact);
            Category = category;

            ValidateFieldsThrowIfInvalid();
            CalculateDiscountPercentage();
        }

        public void ValidateFieldsThrowIfInvalid()
        {
            var error = string.IsNullOrEmpty(Description) || CategoryId <= 0 || CustomerId <= 0;

            if (error)
            {
                throw new ArgumentNullException("One or more fields are incorret");
            }
        }

        public void CalculateDiscountPercentage()
        {
            if (Status == StatusLead.Accepted && Price > 500)
            {
                DiscountPercentage = 10;
            }
        }

        public bool ShouldSendEmail()
        {
            return Price > 500;
        }
    }
}
