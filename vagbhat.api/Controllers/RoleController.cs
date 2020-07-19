using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain.Application.Queries;
using vagbhat.api.Extensions;
using Contracts.RequestModels;
using Domain.Dtos;
using Domain.Application.Commands;
using Contracts.ResponseModels;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Domain.Options;
using AutoMapper;
using Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vagbhat.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public RoleController(IMediator mediator
            , IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<RoleResponse>))]
        [Authorize(Roles = AllowedRoles.Super_Admin)]
        public async Task<IActionResult> Get()
        {
            var query = new GetRolesQuery();
            var result = await mediator.Send(query);
            return Ok(mapper.Map<List<RoleResponse>>(result));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [Authorize(Roles = AllowedRoles.Super_Admin)]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetRoleQueryAsync(id);
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound(id);
            }

            //return Ok(result.ToRoleResponse());
            return Ok(mapper.Map<RoleResponse>(result));
        }

        // POST api/<RoleController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [Authorize(Roles = AllowedRoles.Super)]
        public async Task<IActionResult> Post([FromBody] CreateRoleRequest createRequest)
        {
            var dto = mapper.Map<RoleDto>(createRequest);

            var command = new CreateRoleCommandAsync(dto);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return CreatedAtAction(nameof(Get), new { id = result.Id }, mapper.Map<RoleResponse>(result));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [Authorize(Roles = AllowedRoles.Super)]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateRoleRequest editRequest)
        {
            var userDto = mapper.Map<RoleDto>(editRequest);

            if (id != editRequest.Id)
            {
                return BadRequest(new ErrorResponse { Errors = new string[] { "Id does not match" } });
            }

            var command = new EditRoleCommandAsync(userDto);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(mapper.Map<RoleResponse>(result));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [Authorize(Roles = AllowedRoles.Super)]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteRoleCommandAsync(id);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(mapper.Map<RoleResponse>(result));
        }
    }
}
