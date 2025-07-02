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

        public const string EditCourse = @"
        mutation EditCourse($input: EditCourseInput!) {
              editCourse(input: $input) {
                _id
                description
                displayName
                image
                isDemo
                labels
                name
              }
            }";

        public const string AddModule = @"
        mutation AddModule($input: AddModuleInput!) {
              addModule(input: $input) {
                _id
                displayName
                name
                description
                interactions {
                  _id
                  description
                  displayName
                  duration
                  name
                  score
                }
              }
            }";

        public const string EditModule = @"
        mutation EditModule($input: EditModuleInput!) {
              editModule(input: $input) {
                _id
                displayName
                name
                description
                interactions {
                  _id
                  description
                  displayName
                  duration
                  name
                  score
                }
              }
            }";

        public const string AddInteraction = @"
        mutation AddInteraction($input: AddInteractionInput!) {
              addInteraction(input: $input) {
                _id
                displayName
                name
                description
                score
                duration
              }
            }";

        public const string EditInteraction = @"
        mutation EditInteraction($input: EditInteractionInput!) {
              editInteraction(input: $input) {
                _id
                description
                displayName
                duration
                name
                score
              }
            }";

    }
}