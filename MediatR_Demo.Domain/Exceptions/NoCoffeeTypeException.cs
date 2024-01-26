using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR_Demo.Domain.Exceptions
{
    public class NoCoffeeTypeException : Exception
    {
        public NoCoffeeTypeException()
        {
        }

        public NoCoffeeTypeException(string message)
            : base(message)
        {
        }

        public NoCoffeeTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
