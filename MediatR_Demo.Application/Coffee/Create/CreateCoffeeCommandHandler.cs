using MediatR;
using MediatR_Demo.Application.Interfaces;
using MediatR_Demo.Domain;
using MediatR_Demo.Infrastructure;

namespace MediatR_Demo.Application.Coffee.Create
{
    public class CreateCoffeeCommandHandler : IRequestHandler<CreateCoffeeCommand, Guid>
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IPhysicalCoffeeMachine _physicalCoffeeMachine;

        public CreateCoffeeCommandHandler(ICoffeeRepository coffeeRepository, IPhysicalCoffeeMachine physicalCoffeeMachine)
        {
            this._coffeeRepository = coffeeRepository;
            this._physicalCoffeeMachine = physicalCoffeeMachine;
        }

        public async Task<Guid> Handle(CreateCoffeeCommand request, CancellationToken cancellationToken)
        {
            //Create a coffee
            //Don't inject any kind of services into the Aggregate
            var orderedCoffee = new Domain.Coffee(Enum.Parse<CoffeeType>(request.CoffeeType.ToString()));
            orderedCoffee.AddMilk(request.MilkAmount);
            orderedCoffee.AddSugar(request.SugarAmount);

            //Contact an outside device
            //Reminder!!!  don't put any logic in here to check if the recipe complies to API rules of the coffee machine
            //That ACL implementation belongs in the CoffeeMachine API code... NOT in your code
            _physicalCoffeeMachine.BuildCoffee(orderedCoffee);

            //The coffee repository contains NO business logic, only technical implementation
            await _coffeeRepository.StoreCoffeeAsync(orderedCoffee, cancellationToken);
            
            return orderedCoffee.Id;

        }
    }
}
