namespace ARK.SDK.Queries.Content
{
    public static class ContentQueries
    {
        public const string AddCourse = @"
        mutation AddCourse($input: AddCourseInput!) {
              addCourse(input: $input) {
                _id
                description
                displayName                
                image
                isDemo
                labels
                name
              }
            }";
    }
}