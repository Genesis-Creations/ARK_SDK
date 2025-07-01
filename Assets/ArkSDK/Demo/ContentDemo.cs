using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using UnityEngine;

namespace ARK.SDK.Demo
{
    public class ContentDemo : MonoBehaviour
    {
        [ContextMenu("AddCourse")]
        public async void AddCourse()
        {
            AddCourseInput addCourseInput = new AddCourseInput()
            {
                Description = "This is a demo course",
                DisplayName = "Demo Course6",
                Image = "https://example.com/image.png",
                IsDemo = true,
                Labels = new string[] { "demo", "course" },
                Name = "Demo Course Name6",
                Organization = "670b73dee7636d86d195eef0"
            };

            var result = await ARKManager.Content.AddCourseAsync(addCourseInput);

            Debug.Log($"Course Added: {result.id}");
        }
    }
}