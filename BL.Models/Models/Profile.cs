using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class Profile
    {
        public Credential Credential { get; set; } = new Credential();
        public string Role { get; set; }
        public bool Equals(Credential credential)
        {
            var result = credential.Login == Credential.Login && credential.Password == Credential.Password;

            return result;
        }
    }
}
