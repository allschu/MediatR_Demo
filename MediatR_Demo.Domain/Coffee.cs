using MediatR_Demo.Domain.Exceptions;

namespace MediatR_Demo.Domain
{
    public class Coffee
    {
        public Guid Id { get; }
        public string Name { get; }
        public double SugarAmount { get; private set; }
        public double MilkAmount { get; private set; }

        public CoffeeType Type { get; }

        public Coffee(CoffeeType type)
        {
            if (type == CoffeeType.None) //Guard.... BUT... this could also be fetched validation in API endpoint?
                throw new NoCoffeeTypeException();

            //add additional parameters or use a factory to construct the instance
            Id = Guid.NewGuid();
            Type = type;
            Name = Enum.GetName(type);
        }


        public void AddMilk(double amount)
        {
            if (Type == CoffeeType.Black)
            {
                //THROW ERROR cannot add milk for a black coffee recipe
            }
            else
            {
                if (MilkAmount > 0)
                {
                    if (Type == CoffeeType.Latte)
                    {
                        //extra milk is no problem for a Latte
                    }
                    else
                    {
                        //WARNING Milk is already added, too much?


                    }
                }
                else
                {
                    MilkAmount = amount;
                }
            }
        }

        public void AddSugar(double amount)
        {
            SugarAmount = amount;
        }
    }
}
