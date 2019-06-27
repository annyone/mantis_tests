using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.IO;


namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.UploadFile("/config_inc.php", localFile);
            }   
        }

        [Test]
        public void AccountCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "TestUser1",
                Password = "Password",
                Email = "testuser1@localhost.domain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);

        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
