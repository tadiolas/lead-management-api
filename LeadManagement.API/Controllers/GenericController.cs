using LeadManagement.Domain.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using LeadManagement.Application.Commands.Generic.Create;
using LeadManagement.Application.Commands.Generic.Update;
using LeadManagement.Application.Commands.Generic.Delete;

namespace LeadManagement.API.Controllers
{
    public abstract class GenericController<T> : ControllerBase where T : class
    {
        protected readonly ISender _sender;

        protected GenericController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<T>>> Create([FromBody] T entity)
        {
            await _sender.Send(new CreateEntityRequest<T>(entity));
            return Ok(new BaseResponse<bool> { Data = true });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<T>>> Update([FromRoute] int id, [FromBody] T entity)
        {
            await _sender.Send(new UpdateEntityRequest<T>(id, entity));
            return Ok(new BaseResponse<bool> { Data = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<T>>> Delete([FromRoute] int id)
        {
            await _sender.Send(new DeleteEntityRequest<T>(id));
            return Ok(new BaseResponse<bool> { Data = true });
        }
    }
}
