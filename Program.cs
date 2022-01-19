using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ass_3
{
    class Program
    {
        delegate bool CheckIfNumberIsPrime(int number);
        static async Task Main(string[] args) {
            int min = 0 , max = 100;
            var results = await GetPrimeNumberAsync(min,max, IsPrimeNumberBasic);
             Console.WriteLine($"Total numbers : {results.Count} ");
            PrintNumbers(results); 
             
        }
        static List<int> GetPrimeNumber(int min, int max){
            var results = new List<int>();
            for(int i= min; i <= max; i++)
            {
                if(IsPrimeNumber(i))
                {
                    results.Add(i);
                }
            }
            return results;
        } 
        static async Task<List<int>> GetPrimeNumberAsync(int min, int max, CheckIfNumberIsPrime checker){ 
            var sw = new Stopwatch();
            sw.Start();

            var list = new List<int>();
            var results = await Task.Factory.StartNew(() =>
            {   for(int i= min; i <= max; i++)
                {
                    if(checker(i))
                    {
                        list.Add(i);
                    }
                }
                return list;
            });
            Console.WriteLine($"Time : [{sw.ElapsedMilliseconds}]");
            return results;
        } 
        static void PrintNumbers(List<int> numbers){
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
        static bool IsPrimeNumber(int number){
            if(number <2) return false;
            int i;
            var boundary = (int)Math.Floor(Math.Sqrt(number ));
            for(i = 2; i<= boundary; i++)
            {
                if(number % i ==0) return false;
            }
            return true; 
        }
        static bool IsPrimeNumberBasic(int number){
            if(number <2) return false;
            int i;
            var boundary = (int)Math.Floor(Math.Sqrt(number ));
            for(i = 2; i<= boundary; i++)
            {
                if(number % i ==0) return false;
            }
            return true;
        }
    }
}