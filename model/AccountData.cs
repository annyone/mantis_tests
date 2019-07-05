namespace mantis_tests
{
    public class AccountData
    {
        public AccountData()
        {
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public int Id { get; internal set; }

        public AccountData(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public AccountData(string username, int id)
        {
            Username = username;
            Id = id;
        }
    }
}
