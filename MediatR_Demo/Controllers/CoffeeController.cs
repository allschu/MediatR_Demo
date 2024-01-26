using MediatR;
using MediatR_Demo.Application.Coffee.Create;
using MediatR_Demo.Application.Coffee.Get;
using MediatR_Demo.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoffeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Request 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(Get))]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var dto = await _mediator.Send(new GetCoffeeByIdQuery(new Guid(id)), cancellationToken);

            return Ok(dto);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(OrderCoffeeRequest request, CancellationToken cancellationToken)
        {
           var createdId = await _mediator.Send(new 
                CreateCoffeeCommand(
                    request.CoffeeType, 
                    request.MilkAmount, 
                    request.SugarAmount), cancellationToken);

           return CreatedAtRoute(nameof(Get), new { id = createdId }, createdId);
        }

    }
}
