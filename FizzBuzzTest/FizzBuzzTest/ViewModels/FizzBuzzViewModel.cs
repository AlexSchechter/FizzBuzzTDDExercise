using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzTest.ViewModels
{
    public class FizzBuzzViewModel
    {
        public int Input { get; set; }
        public List<string> Sequence { get; set; }
        public int? Section { get; set; }
    }
}