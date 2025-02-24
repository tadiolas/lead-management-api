using MediatR;

namespace LeadManagement.Application.Commands.Generic.Create
{
    public class CreateEntityRequest<T> : IRequest
    {
        public T Entity { get; set; }

        public CreateEntityRequest(T entity)
        {
            Entity = entity;
        }
    }
}
