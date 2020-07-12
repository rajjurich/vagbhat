using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Application.Commands;
using Domain.Application.Queries;
using Domain.Dtos;
using Domain.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vagbhat.api.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vagbhat.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AllowedRoles.Super)]
    public class AssociationController : ControllerBase
    {
        private readonly IMediator mediator;
        private static readonly Expression<Func<AssociationDto, AssociationResponse>> AsAssociationResponse =
           x => new AssociationResponse
           {
               Id = x.Id,
               AssociationName = x.AssociationName
           };

        public AssociationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<AssociationController>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<AssociationResponse>))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAssociationsQuery();
            var result = await mediator.Send(query);
            return Ok(result.Select(AsAssociationResponse));
        }

        // GET api/<AssociationController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssociationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetAssociationQueryAsync(id);
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound(id);
            }

            return Ok(result.ToAssociationResponse());
        }

        // POST api/<AssociationController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AssociationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Post([FromBody] AssociationRequest createRequest)
        {
            var dto = createRequest.ToAssociactionDto();

            var command = new CreateAssociationCommandAsync(dto);

            var result = await mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result.ToAssociationResponse());
        }

        // PUT api/<AssociationController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssociationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Put(string id, [FromBody] AssociationRequest editRequest)
        {
            var dto = editRequest.ToAssociactionDto();
            dto.Id = id;

            var command = new EditAssociationCommandAsync(dto);

            var result = await mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result.ToAssociationResponse());
        }

        // DELETE api/<AssociationController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssociationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteAssociationCommandAsync(id);

            var result = await mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result.ToAssociationResponse());
        }
    }
}
