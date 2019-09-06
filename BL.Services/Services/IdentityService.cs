using BL.Models;
using DL;
using DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class IdentityService
    {
        private IdentityRepository _identityRepository = new IdentityRepository();
        public Profile Login(Credential credential)
        {
            var result = _identityRepository.Items.Where(x => x.Equals(credential)).FirstOrDefault();

            return result;
        }
    }
}
