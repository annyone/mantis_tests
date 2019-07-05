using System.Collections.Generic;
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
                Username = "TestUser9",
                Password = "Password",
                Email = "testuser9@localhost.domain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Username == account.Username);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }
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
