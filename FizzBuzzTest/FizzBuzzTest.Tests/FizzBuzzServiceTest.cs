using System;
using NUnit.Framework;
using FizzBuzzTest.Services;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzTest.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTest
    {
        private FizzBuzzService _fizzBuzzService;
        private string _actualResult;
        private List<string> _actualResultSequence;

        //[TestCase(1, "1")]
        //[TestCase (3, "fizz")]
        //[TestCase(5, "buzz")]
        //[TestCase(15, "fizz buzz")]
        //[TestCase(98, "98")]
        //[TestCase(100, "buzz")]
        //public void WhenNumberProvidedReturnFizzBuzz(int number, string outcome)
        //{
        //    GivenFizzBuzzServiceClass();
        //    WhenFizzBuzzIsCalledWith(number);
        //    ThenStringIsEqualTo(outcome);

        //}

        [TestCase(1, true, "1")]
        [TestCase(3, true, "wizz")]
        [TestCase(5, true, "wuzz")]
        [TestCase(15, true, "wizz wuzz")]
        [TestCase(98, true, "98")]
        [TestCase(100, true, "wuzz")]
        [TestCase(1, false, "1")]
        [TestCase(3, false, "fizz")]
        [TestCase(5, false, "buzz")]
        [TestCase(15, false, "fizz buzz")]
        [TestCase(98, false, "98")]
        [TestCase(100, false, "buzz")]
        public void WhenNumberProvidedReturnFizzBuzz(int number, bool isWednesday, string outcome)
        {
            GivenFizzBuzzServiceClass();
            WhenFizzBuzzIsCalledWith(number, isWednesday);
            ThenStringIsEqualTo(outcome);

        }
    
        [TestCase (1, false, new[] { "1" })]
        [TestCase(5, false, new[] { "1", "2", "fizz", "4", "buzz"})]
        [TestCase(15, false, new[] { "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizz buzz"})]
        [TestCase(1, true, new[] { "1" })]
        [TestCase(5, true, new[] { "1", "2", "wizz", "4", "wuzz" })]
        [TestCase(15, true, new[] { "1", "2", "wizz", "4", "wuzz", "wizz", "7", "8", "wizz", "wuzz", "11", "wizz", "13", "14", "wizz wuzz" })]
        public void WhenNumberProvidedReturnFizzBuzzSequence(int number, bool isWednesday, string[] outcome)
        {
            GivenFizzBuzzServiceClass();
            WhenFizzBuzzSequenceIsCalledWith(number, isWednesday);
            ThenSequenceIsEqualTo(outcome);
        }

        private void GivenFizzBuzzServiceClass()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        private void WhenFizzBuzzIsCalledWith(int number, bool isWednesday)
        {
            _actualResult = _fizzBuzzService.FizzBuzz(number, isWednesday);
        }

        private void ThenStringIsEqualTo(string outcome)
        {
            Assert.AreEqual(outcome, _actualResult);
        }

        private void WhenFizzBuzzSequenceIsCalledWith(int number, bool isWednesday)
        {
            _actualResultSequence = _fizzBuzzService.FizzBuzzSequence(number, isWednesday);
        }

        private void ThenSequenceIsEqualTo(string[] outcome)
        {
            CollectionAssert.AreEqual(outcome.ToList(), _actualResultSequence);
        }
    }
}
