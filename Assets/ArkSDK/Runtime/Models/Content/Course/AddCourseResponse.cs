using ARK.SDK.Models.Auth;
using Newtonsoft.Json;
using System;

namespace ARK.SDK.Models.Content
{
    public class AddCourseResponse
    {
        [JsonProperty("addCourse")]
        public CourseData CourseData { get; private set; }
    }
}