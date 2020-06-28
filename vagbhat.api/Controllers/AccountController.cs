using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.RequestModels;
using Models.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vagbhat.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: api/<AccountController>/Login
        [HttpPost(ApiRoutes.Accounts.Login)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginSuccessModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(LoginFailedModel))]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(new LoginFailedModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToArray()
                });
            }
            var response = await accountService.LoginAsync(loginRequestModel);
            if (!(response.Success))
            {
                return BadRequest(new LoginFailedModel
                {
                    Errors = response.Errors
                });
            }
            return Ok(new LoginSuccessModel
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        // GET: api/<AccountController>/Refresh
        [HttpPost(ApiRoutes.Accounts.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginSuccessModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(LoginFailedModel))]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestModel refreshRequestModel)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(new LoginFailedModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToArray()
                });
            }
            var response = await accountService
                .RefreshTokenAsync(refreshRequestModel.Token, refreshRequestModel.RefreshToken);

            if (!(response.Success))
            {
                return BadRequest(new LoginFailedModel
                {
                    Errors = response.Errors
                });
            }
            return Ok(new LoginSuccessModel
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
