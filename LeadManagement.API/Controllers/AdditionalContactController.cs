using LeadManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/additional-contact")]
    public class AdditionalContactController : GenericController<AdditionalContact>
    {
        public AdditionalContactController(ISender sender) : base(sender)
        {
        }
    }
}