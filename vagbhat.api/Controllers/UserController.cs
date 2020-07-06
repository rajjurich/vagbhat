using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using MediatR;
using Domain.Application.Queries;
using vagbhat.api.Extensions;
using Contracts.RequestModels;
using Domain.Dtos;
using Domain.Application.Commands;
using Contracts.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vagbhat.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<User>))]
        public async Task<IActionResult> Get()
        {
            var query = new GetUsersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetUserQueryAsync(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest userRequest)
        {
            if (userRequest.Password.Equals(userRequest.ConfirmPassword))
            {
                return BadRequest(new string[] { "Password and Confirm Password does not match" });
            }

            var command = new CreateUserCommandAsync(GetUserDto(userRequest));
            var result = await mediator.Send(command);
            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            foreach (var role in result.Roles)
            {
                var roleResponse = new RoleResponse
                {
                    Id=role.
                }
            }
            var roles = 
            return Ok(new UserResponse
            {
                Email = result.Email,
                Id=result.Id,
                Roles=result.Roles

                );
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [NonAction]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [NonAction]
        public void Delete(int id)
        {
        }

        private static UserDto GetUserDto(UserRequest userRequest)
        {
            List<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var role in userRequest.Roles)
            {
                var roleDto = new RoleDto
                {
                    RoleName = role.RoleName
                };

                roleDtos.Add(roleDto);
            }

            var userDto = new UserDto
            {
                Email = userRequest.Email,
                Roles = roleDtos
            };

            return userDto;
        }
    }
}
