using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddCourseVariables
    {
        [JsonProperty("input")]
        public AddCourseInput Input { get; set; }

        public AddCourseVariables(AddCourseInput addCourseInput)
        {
            Input = addCourseInput;
        }
    }
}
