using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("cinema")]
    public class CinemaController : Controller
    {

        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> getAllCinemas()
        {
            var cinemas = await _mediator.Send(new GetAllCinemaQuery());
            return Ok(cinemas);
        }

        [HttpPost]
       public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addmodel) 
       {
            var cinema = new Cinema
            {
                City = addmodel.City,
                Name = addmodel.Name,
                Street = addmodel.Street,
                NumberOfAuditoriums = addmodel.NumberOfAuditoriums

            };
            var result = await _mediator.Send(new AddCinemaCommand());
            return Ok(result);
        }
    }
}



 

   



