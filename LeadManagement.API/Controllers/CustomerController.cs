using LeadManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : GenericController<Customer>
    {
        public CustomerController(ISender sender) : base(sender)
        {
        }
    }
}
