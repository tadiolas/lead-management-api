﻿using LeadManagement.Application.Commands.Leads.Update;
using LeadManagement.Application.Queries.Leads;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Entities.Response;
using LeadManagement.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
    [ApiController]
    [Route("api/lead")]
    public class LeadController : GenericController<Lead>
    {

        public LeadController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Lead>>>> GetAllLeads([FromQuery] StatusLead status)
        {
            var result = await _sender.Send(new GetLeadsByStatusRequest(status));
            return Ok(new BaseResponse<IEnumerable<Lead>> { Data = result });
        }

        public override async Task<ActionResult<BaseResponse<Lead>>> Update([FromRoute] int id, [FromBody] Lead entity)
        {
            await _sender.Send(new UpdateLeadRequest(id, entity));
            return Ok(new BaseResponse<bool> { Data = true });
        }

    }
}
