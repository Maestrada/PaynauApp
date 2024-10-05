using Microsoft.AspNetCore.Mvc;
using MediatR;
using PaynauApp_Application.Queries;
using PaynauApp_Domain.Entities;


namespace PaynauApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await _mediator.Send(new GetPersonasQuery());
        }
    }
}
