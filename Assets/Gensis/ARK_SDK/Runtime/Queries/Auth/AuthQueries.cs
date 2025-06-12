namespace ARK.SDK.Queries.Auth
{
    public static class AuthQueries
    {
        public const string Login = @"
        mutation LoginAsync($email: String!, $password: String!) {
            login(email: $email, password: $password) {
                accessToken
            }
        }";
    }
}