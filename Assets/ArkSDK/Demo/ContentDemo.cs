using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class ContentDemo : MonoBehaviour
    {
        [Header("AddCourse")]
        public ContentAddCourseDemo contentAddCourseDemo;

        [Header("EditCourse")]
        public ContentEditCourseDemo contentEditCourseDemo;


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