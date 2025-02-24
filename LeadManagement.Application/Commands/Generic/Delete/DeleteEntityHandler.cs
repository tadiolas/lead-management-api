using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Generic.Delete
{
    public class DeleteEntityHandler<T> : IRequestHandler<DeleteEntityRequest<T>>
    {
        private readonly IGenericCommandRepository<T> _genericRepository;
        public DeleteEntityHandler(IGenericCommandRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(DeleteEntityRequest<T> request, CancellationToken cancellationToken)
        {
            await _genericRepository.DeleteAsync(request.Id);
        }
    }
}
