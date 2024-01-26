using MediatR_Demo.Application.Interfaces;

namespace MediatR_Demo.Application.Adapters
{
    public class PhysicalCoffeeMachine : IPhysicalCoffeeMachine
    {

        public PhysicalCoffeeMachine()
        {

        }

        public void BuildCoffee(Domain.Coffee recipe)
        {
            //implementation logic
        }

        public void ChangeCoffeeMachineConfiguration(ConfigurationSettings configuration)
        {
            //implement logic
        }
    }
}
