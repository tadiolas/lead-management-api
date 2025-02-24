namespace LeadManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
