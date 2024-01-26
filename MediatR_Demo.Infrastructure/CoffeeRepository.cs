
using MediatR_Demo.Domain;

namespace MediatR_Demo.Infrastructure
{
    public class CoffeeRepository : ICoffeeRepository
    {
        public List<Coffee> CoffeeList { get; set; } = new();

        public async Task StoreCoffeeAsync(Coffee coffee, CancellationToken cancellationToken)
        {
            CoffeeList.Add(coffee);
        }

        public async Task<Coffee> GetCoffeeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var coffee  = CoffeeList.Find(c => c.Id == id);

            return coffee == null ? throw new InvalidOperationException("coffee with id does not exist") : coffee;
        }

    }
}
