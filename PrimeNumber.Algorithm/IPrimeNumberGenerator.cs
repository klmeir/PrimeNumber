using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Algorithm
{
    public interface IPrimeNumberGenerator
    {
        List<int> GeneratePrimeNumbers(int start, int count);
    }
}
