
using MediatR;

namespace MediatR_Demo.Application.Coffee.Create
{
    public class CreateCoffeeCommand : IRequest<Guid>
    {
        public double SugarAmount { get; }
        public double MilkAmount { get;  }
        public int CoffeeType { get; }
        public CreateCoffeeCommand(int coffeeType, double milkAmount, double sugarAmount)
        {
            CoffeeType = coffeeType;
            MilkAmount = milkAmount;
            SugarAmount = sugarAmount;
        }
    }
}
