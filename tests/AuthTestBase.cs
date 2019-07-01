using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.LogIn(new AccountData("administrator", "password"));
        }

    }
}
