using System.ComponentModel.DataAnnotations;

namespace MediatR_Demo.Contract
{
    public class OrderCoffeeRequest
    {
        
        public double SugarAmount { get; set; }
        public double MilkAmount { get; set; }
        public int CoffeeType { get; set; }
    }
}
