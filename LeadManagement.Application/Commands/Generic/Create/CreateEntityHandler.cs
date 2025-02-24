using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Generic.Create
{
    public class CreateEntityHandler<T> : IRequestHandler<CreateEntityRequest<T>>
    {
        private readonly IGenericCommandRepository<T> _genericRepository;
        public CreateEntityHandler(IGenericCommandRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(CreateEntityRequest<T> request, CancellationToken cancellationToken)
        {
            await _genericRepository.CreateAsync(request.Entity);
        }
    }
}
