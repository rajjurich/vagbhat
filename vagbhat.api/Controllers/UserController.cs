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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AllowedRoles.Super_Admin, Policy = CreatedPolicies.Deleted)]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UserController(IMediator mediator
            , IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<UserResponse>))]
        public async Task<IActionResult> Get()
        {
            var query = new GetUsersQuery();
            var result = await mediator.Send(query);
            return Ok(mapper.Map<List<UserResponse>>(result));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetUserQueryAsync(id);
            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound(id);
            }

            //return Ok(result.ToUserResponse());
            return Ok(mapper.Map<UserResponse>(result));
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest createRequest)
        {
            var dto = mapper.Map<UserDto>(createRequest);

            var command = new CreateUserCommandAsync(dto);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return CreatedAtAction(nameof(Get), new { id = result.Id }, mapper.Map<UserResponse>(result));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserRequest editRequest)
        {
            var userDto = mapper.Map<UserDto>(editRequest);

            if (id != editRequest.Id)
            {
                return BadRequest(new ErrorResponse { Errors = new string[] { "Id does not match" } });
            }

            var command = new EditUserCommandAsync(userDto);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(mapper.Map<UserResponse>(result));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteUserCommandAsync(id);

            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(mapper.Map<UserResponse>(result));
        }
    }
}
