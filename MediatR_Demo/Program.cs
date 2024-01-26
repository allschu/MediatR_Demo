using FluentValidation;
using MediatR;
using MediatR_Demo.Application.Adapters;
using MediatR_Demo.Application.Common;
using MediatR_Demo.Application.Interfaces;
using MediatR_Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICoffeeRepository, CoffeeRepository>();
builder.Services.AddTransient<IPhysicalCoffeeMachine, PhysicalCoffeeMachine>();

builder.Services.AddValidatorsFromAssemblyContaining(typeof(MediatR_Demo.Application.Coffee.Create.CreateCoffeeCommand));

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblyContaining(typeof(MediatR_Demo.Application.Coffee.Create.CreateCoffeeCommand));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
    //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
