using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Repka01.Data
{
    class UserCredentials
    {
        public static readonly Dictionary<string, User> users = new Dictionary<string, User>()
        {
            { "Test", new User {Email = "test@test.ru", Password = "123456"}}
        };
    }
    class User
    {
        public string Email;
        public string Password;
    }
}
