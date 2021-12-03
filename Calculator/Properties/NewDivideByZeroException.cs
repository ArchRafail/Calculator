using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Properties
{
    class NewDivideByZeroException : Exception
    {
        public NewDivideByZeroException() : base("Error. Division by zero") { }
    }
}
