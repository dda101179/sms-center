using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Repositories
{
    public class IdentityRepository
    {
        private List<Profile> _profiles { get; set; } = new List<Profile>();
        public IdentityRepository()
        {
            _initFakeData();
        }
        public IEnumerable<Profile> Items { get => _profiles.AsReadOnly(); }
        private void _initFakeData()
        {
            _profiles.AddRange(new List<Profile>() {
                new Profile { Credential = new Credential(){ Login="admin", Password="sdgk5wf5$%df" }, Role = "admins" },
                new Profile { Credential = new Credential(){ Login="user", Password="gkasdfhdsfg%df" }, Role = "users" },
                new Profile { Credential = new Credential(){ Login="r00t", Password="x777ak" }, Role = "admin" },
            });
        }
    }
}
