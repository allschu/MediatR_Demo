using MediatR_Demo.Application.Adapters;
using MediatR_Demo.Domain;

namespace MediatR_Demo.Application.Interfaces
{
    public interface IPhysicalCoffeeMachine
    {
        void ChangeCoffeeMachineConfiguration(ConfigurationSettings configuration);

        void BuildCoffee(Domain.Coffee recipe);
    }
}
