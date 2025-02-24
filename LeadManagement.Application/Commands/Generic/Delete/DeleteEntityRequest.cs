using MediatR;

namespace LeadManagement.Application.Commands.Generic.Delete
{
    public class DeleteEntityRequest<T> : IRequest
    {
        public int Id { get; set; }

        public DeleteEntityRequest(int id)
        {
            Id = id;
        }

    }
}
