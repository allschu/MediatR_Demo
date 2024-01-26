using MediatR;
using MediatR_Demo.Application.Coffee.Get.DTO;

namespace MediatR_Demo.Application.Coffee.Get
{
    public class GetCoffeeByIdQuery : IRequest<CoffeeDto>
    {
        public Guid Id { get; }
        public GetCoffeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
