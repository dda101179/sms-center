using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class Receiver
    {
        public string PhoneNumber { get; set; }
        public bool IsValid()
        {
            var result = true;

            return result;
        }
    }
}
