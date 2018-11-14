using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(checkSmithNumber(778));

            Console.ReadLine();
        }

        private static bool checkSmithNumber(int v)
        {
            if (numberPrimeFactorDigitSum(v) == numberDigitSum(v))
                return true;
            else
                return false;
        }

        private static int numberPrimeFactorDigitSum(int v)
        {
            int sum = 0;

            foreach (var item in primeFactors(v))
            {
                sum += numberDigitSum(item);
            }

            return sum;
        }

        private static int numberDigitSum(int v)
        {
            int sum = 0;

            while(v != 0)
            {
                sum += v % 10;
                v /= 10;
            }

            return sum;
        }

        private static List<int> primeFactors(int v)
        {
            List<int> primeFactList = new List<int>();

            int i = 1;

            while (v != 1)
            {
                int divisor = generatePrimeNumbers(i)[generatePrimeNumbers(i).Count - 1];

                if (v % divisor == 0)
                {
                    primeFactList.Add(divisor);
                    v /= divisor;
                }
                    
                else
                    i++;
            }

            return primeFactList;
        }

        private static bool checkPrime(int v)
        {
            for (int i = 2; i < v; i++)
            {
                if (v % i == 0)
                    return false;
            }

            return true;
        }

        private static List<int> generatePrimeNumbers(int v)
        {
            List<int> primeList = new List<int>();

            for (int i = 2; true; i++)
            {
                if (checkPrime(i))
                {
                    if (primeList.Count != v)
                        primeList.Add(i);
                    else
                        break;
                }
            }

            return primeList;
        }
    }
}