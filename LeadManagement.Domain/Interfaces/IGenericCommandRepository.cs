namespace LeadManagement.Domain.Interfaces
{
    public interface IGenericCommandRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
