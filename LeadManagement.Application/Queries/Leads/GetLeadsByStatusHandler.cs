using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using MediatR;

namespace LeadManagement.Application.Queries.Leads
{
    public class GetLeadsByStatusHandler : IRequestHandler<GetLeadsByStatusRequest, IEnumerable<Lead>>
    {
        private readonly ILeadQueryRepository _leadRepository;
        public GetLeadsByStatusHandler(ILeadQueryRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<IEnumerable<Lead>> Handle(GetLeadsByStatusRequest request, CancellationToken cancellationToken)
        {
            return await _leadRepository.GetLeadsByStatus(request.Status);
        }
    }
}
