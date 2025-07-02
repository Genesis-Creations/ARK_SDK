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
                DisplayName = "Demo Course14",
                Image = "https://example.com/image.png",
                IsDemo = true,
                Labels = new string[] { "demo", "course" },
                Name = "Demo Course Name14",
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
                Id = "6863d1e1a329e25595146ec7", 
                Description = "This is an demo course"
            };

            var result = await ARKManager.Content.EditCourseAsync(editCourseInput);

            Debug.Log($"Course Edited: {result.CourseData.Description}");
        }

        [ContextMenu("AddModule")]
        public async void AddModule()
        {
            AddModuleInput addModuleInput = new AddModuleInput()
            {
                CourseId = "670b73e4e7636d86d196008c",
                Description = "Added Module Desc2",
                DisplayName = "Added Module2",
                Name = "Added Module Name2",
            };

            var result = await ARKManager.Content.AddModuleAsync(addModuleInput);

            Debug.Log($"Course Added: {result.ModuleData.Id}");
        }
    }
}