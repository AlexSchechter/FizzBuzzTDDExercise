using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzTest.Services
{
    public class FizzBuzzService
    {
        public const int fizz = 3;
        public const int buzz = 5;
        public const int fizzBuzz = 15;
         
        public string FizzBuzz(int number, bool isWednesday)
        {
            if (number % fizzBuzz == 0)
                return isWednesday? "wizz wuzz": "fizz buzz";
            else if (number % buzz == 0)
                return isWednesday? "wuzz": "buzz";
            else if (number % fizz == 0)
                return isWednesday? "wizz": "fizz";

            return number.ToString();
        }

        public List<string> FizzBuzzSequence(int number, bool isWednesday)
        {

            List<string> sequence = new List<string>();

            for (int i = 0; i < number; i++)           
                sequence.Add(FizzBuzz(i + 1, isWednesday));
            
            return sequence;
        }
    }    
 
}