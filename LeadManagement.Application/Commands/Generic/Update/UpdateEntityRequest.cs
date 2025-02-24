using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Generic.Update
{
    public class UpdateEntityRequest<T> : IRequest
    {
        public int Id { get; set; }
        public T Entity { get; set; }

        public UpdateEntityRequest(int id, T entity)
        {
            Id = id;
            Entity = entity;
        }
    }
}
