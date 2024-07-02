﻿namespace PrimeNumber.Algorithm
{
    public class PrimeNumberGenerator : IPrimeNumberGenerator
    {
        public List<int> GeneratePrimeNumbers(int start, int count)
        {
            List<int> primeNumbers = new List<int>();

            while (primeNumbers.Count < count)
            {
                if (IsPrime(start))
                {
                    primeNumbers.Add(start);
                }
                start++;
            }

            return primeNumbers;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
