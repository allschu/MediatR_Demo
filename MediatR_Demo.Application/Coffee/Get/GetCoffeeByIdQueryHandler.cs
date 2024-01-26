using MediatR;
using MediatR_Demo.Application.Coffee.Get.DTO;
using MediatR_Demo.Application.Mappings;
using MediatR_Demo.Infrastructure;

namespace MediatR_Demo.Application.Coffee.Get
{
    public class GetCoffeeByIdQueryHandler : IRequestHandler<GetCoffeeByIdQuery, CoffeeDto>
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public GetCoffeeByIdQueryHandler(ICoffeeRepository repository)
        {
            this._coffeeRepository = repository;
        }
        
        public async Task<CoffeeDto> Handle(GetCoffeeByIdQuery request, CancellationToken cancellationToken)
        {
            var coffee = await _coffeeRepository.GetCoffeeByIdAsync(request.Id, cancellationToken);

            //the results needs to be send back.
            //Map it back to a DTO
            var coffeeDto = coffee.MapToDto();

            return coffeeDto;
        }
    }
}
