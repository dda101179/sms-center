using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public class ConsolePrintService
    {
        private string _responseString { get; set; }
        public ConsolePrintService SetResponse(string response)
        {
            _responseString = response;

            return this;
        }
        public void Print()
        {
            Console.WriteLine($"Response:\n{_responseString}");
        }
    }
}
