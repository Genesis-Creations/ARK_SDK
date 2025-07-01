using Newtonsoft.Json;
using System;

namespace ARK.SDK.Models.Content
{
    public class EditCourseResponse
    {
        [JsonProperty("editCourse")]
        public CourseData CourseData { get; private set; }
    }
}