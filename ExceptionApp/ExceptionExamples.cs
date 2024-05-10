using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    internal static class ExceptionExamples
    {
        public static double SomeAction(double a, double b)
        {
            double result = 0;
            try
            {
                if (b == 0)
                    throw new DivideByZeroException();
                else
                    result = a / b;
                // ...
            }
            catch (DivideByZeroException ex)
            {

                throw new ArgumentException("b should be <> 0", nameof(b), ex);
            }
            return result;
        }
    }
}
