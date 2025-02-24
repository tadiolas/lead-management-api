using LeadManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : GenericController<Category>
    {
        public CategoryController(ISender sender) : base(sender)
        {
        }
    }
}
