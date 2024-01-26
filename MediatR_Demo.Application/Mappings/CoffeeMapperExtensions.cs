using MediatR_Demo.Application.Coffee.Get.DTO;

namespace MediatR_Demo.Application.Mappings
{
    internal static class CoffeeMapperExtensions
    {
        public static CoffeeDto MapToDto(this Domain.Coffee domain)
        {
            return new CoffeeDto()
            {
                Id = domain.Id,
                Name = domain.Name,
                Type = (int)domain.Type
            };
        }
    }
}
