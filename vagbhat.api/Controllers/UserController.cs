using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Model;
using MediatR;
using Domain.Application.Queries;
using Domain.Application.Commands;

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

        // GET: api/<AccountController>/Token
        [HttpPost(ApiRoutes.Accounts.Token)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Token))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Token))]
        public async Task<IActionResult> Token([FromBody] TokenRequestModel tokenRequestModel)
        {

            var command = new CreateTokenCommandAsync(tokenRequestModel);
            var result = await mediator.Send(command);
            if (result.Errors != null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET: api/<AccountController>/Refresh
        [HttpPost(ApiRoutes.Accounts.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Token))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Token))]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestModel refreshRequestModel)
        {
            var command = new CreateRefreshTokenCommandAsync(refreshRequestModel);
            var result = await mediator.Send(command);
            if (result.Errors != null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET: api/<AccountController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<User>))]
        public async Task<IActionResult> Get()
        {
            var query = new GetUsersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetUserQueryAsync(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<AccountController>
        [HttpPost]
        [NonAction]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        [NonAction]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        [NonAction]
        public void Delete(int id)
        {
        }
    }
}
