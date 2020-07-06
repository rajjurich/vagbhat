using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Application.Commands;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vagbhat.api.Extensions;

namespace vagbhat.api.Controllers
{
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: /Token
        [HttpPost(ApiRoutes.Accounts.Token)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Token([FromBody] AccessRequest accessRequest)
        {
            AccessDto accessDto = new AccessDto
            {
                Email = accessRequest.Email,
                Password = accessRequest.Password
            };
            var command = new CreateTokenCommandAsync(accessDto);
            var result = await mediator.Send(command);

            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(new TokenResponse
            {
                Access_Token = result.Access_Token,
                Refresh_Token = result.Refresh_Token
            });
        }

        // GET: /Refresh
        [HttpPost(ApiRoutes.Accounts.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest refreshRequestModel)
        {
            RefreshDto refreshDto = new RefreshDto
            {
                Access_Token = refreshRequestModel.Access_Token,
                Refresh_Token = refreshRequestModel.Refresh_Token
            };

            var command = new CreateRefreshTokenCommandAsync(refreshDto);
            var result = await mediator.Send(command);
            if (result.Errors != null)
            {
                return BadRequest(result.Error(result.Errors));
            }

            return Ok(new TokenResponse
            {
                Access_Token = result.Access_Token,
                Refresh_Token = result.Refresh_Token
            });
        }

    }
}
