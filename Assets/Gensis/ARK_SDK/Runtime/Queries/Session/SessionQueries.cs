namespace ARK.SDK.Queries.Session
{
    public static class SessionQueries
    {
        public const string GetActiveUserSession = @"
        query Query {
            activeUserSession {
                _id
                isTraining
                courses {
                _id
                name
                }
                modules {
                 _id
                name
                }
                interactions {
                _id
                displayName
                name
                }
            }
        }";

        public const string StartUserSession = @"mutation StartUserSession($sessionId: String!) {
            startUserSession(sessionId: $sessionId)
        }";
    }
}