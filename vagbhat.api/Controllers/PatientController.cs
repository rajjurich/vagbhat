using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Application.Commands;
using Domain.Application.Queries;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vagbhat.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PatientController(IMediator mediator
            , IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/<PatientController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<PatientResponse>))]
        public async Task<IActionResult> Get()
        {
            var query = new GetPatientsQuery();
            var result = await mediator.Send(query);
            return Ok(mapper.Map<List<PatientResponse>>(result));
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatientResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PatientResponse))]
        public async Task<IActionResult> Post([FromBody] CreatePatientRequest createPatientRequest)
        {
            var dto = mapper.Map<CreatePatientDto>(createPatientRequest);

            var command = new CreatePatientCommandAsync(dto);

            var result = await mediator.Send(command);

            if (result== null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = result.Id }, mapper.Map<PatientResponse>(result));

        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
