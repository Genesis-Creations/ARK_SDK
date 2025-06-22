namespace ARK.SDK.Queries.Result
{
    public static class ResultQueries
    {
        public const string UpdateUserSession = @"
            mutation updateUserSession($sessionId: String!, $updateUserSessionInput: UserSessionResultInput!) {
            updateUserSession(sessionId: $sessionId, input: $updateUserSessionInput)
                 }";
    }
}