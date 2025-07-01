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
                DisplayName = "Demo Course11",
                Image = "https://example.com/image.png",
                IsDemo = true,
                Labels = new string[] { "demo", "course" },
                Name = "Demo Course Name11",
                Organization = "670b73dee7636d86d195eef0"
            };

            var result = await ARKManager.Content.AddCourseAsync(addCourseInput);

            Debug.Log($"Course Added: {result.CourseData.Id}");
        }

        [ContextMenu("EditCourse")]
        public async void EditCourse()
        {
            EditCourseInput editCourseInput = new EditCourseInput()
            {
                Id = "68639cc1942c8c72826dbba6", 
                Description = "This is an edited again demo course",
                DisplayName = "Demo Course11",
                Image = "https://example.com/image.png",
                IsDemo = true,
                Labels = new string[] { "demo", "course" },
                Name = "Demo Course Name11",
                Organization = "670b73dee7636d86d195eef0"
            };

            var result = await ARKManager.Content.EditCourseAsync(editCourseInput);

            Debug.Log($"Course Added: {result.CourseData.Description}");
        }
    }
}