using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class RequestPackage
    {
        public Credential Credential { get; set; } = new Credential();
        public List<MessageOfRequest> Messages { get; set; } = new List<MessageOfRequest>();
    }
}
