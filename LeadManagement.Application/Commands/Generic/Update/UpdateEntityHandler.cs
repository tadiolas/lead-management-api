using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Commands.Generic.Update
{
    public class UpdateEntityHandler<T> : IRequestHandler<UpdateEntityRequest<T>>
        where T : class, IBaseEntity
    {
        private readonly IGenericCommandRepository<T> _genericRepository;
        public UpdateEntityHandler(IGenericCommandRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(UpdateEntityRequest<T> request, CancellationToken cancellationToken)
        {
            request.Entity.Id = request.Id;
            await _genericRepository.UpdateAsync(request.Entity);
        }
    }
}
