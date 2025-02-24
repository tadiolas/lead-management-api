namespace LeadManagement.Domain.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        void ValidateFieldsThrowIfInvalid();
    }
}
