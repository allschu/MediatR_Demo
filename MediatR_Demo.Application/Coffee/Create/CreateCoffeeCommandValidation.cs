using FluentValidation;

namespace MediatR_Demo.Application.Coffee.Create
{
    public class CreateCoffeeCommandValidation : AbstractValidator<CreateCoffeeCommand>
    {
        public CreateCoffeeCommandValidation()
        {
            //Check
            RuleFor(v => v.CoffeeType)
                .NotNull()
                .NotEqual(0)
                .WithMessage("CoffeeType is mandatory");
        }
    }
}
