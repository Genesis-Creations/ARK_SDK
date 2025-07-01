using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARK.SDK.Models.Content
{
    public class EditCourseVariables
    {
        [JsonProperty("input")]
        public EditCourseInput Input { get; set; }

        public EditCourseVariables(EditCourseInput editCourseInput)
        {
            Input = editCourseInput;
        }
    }
}
