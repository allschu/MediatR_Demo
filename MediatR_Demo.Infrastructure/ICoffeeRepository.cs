using MediatR_Demo.Domain;

namespace MediatR_Demo.Infrastructure
{
    public interface ICoffeeRepository
    {
        Task StoreCoffeeAsync(Coffee  coffee, CancellationToken cancellationToken);

        Task<Coffee> GetCoffeeByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
