namespace ARK.SDK.Models.Auth
{
    public class LoginVariables
    {
        public string email;
        public string password;

        public LoginVariables(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}