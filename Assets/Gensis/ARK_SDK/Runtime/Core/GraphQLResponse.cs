using System.Collections.Generic;

namespace ARK.SDK.Core
{
    public class GraphQLResponse<T>
    {
        public T data;
        public List<GraphQLError> errors;
    }
}