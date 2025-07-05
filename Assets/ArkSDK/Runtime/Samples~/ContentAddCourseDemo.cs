using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ARK.SDK.Demo
{
    public class ContentAddCourseDemo : MonoBehaviour
    {
        public TMP_InputField CourseNameInput;

        public TMP_InputField CourseDescriptionInput;
        public TMP_InputField CourseDisplayNameInput;
        public TMP_InputField CourseLabelsInput; // Comma-separated labels
        public TMP_InputField CourseModulesInput; // Comma-separated module IDs (optional)
        public TMP_InputField CourseOrganizationInput; // Organization ID
        public Toggle CourseIsDemoToggle; // True or False
        public TMP_InputField CourseImageInput;
        public Button AddCourseButton;

        private void OnEnable()
        {
            AddCourseButton.onClick.AddListener(AddCourse);
        }
        private void OnDisable()
        {
            AddCourseButton.onClick.RemoveListener(AddCourse);
        }

        public async void AddCourse()
        {
            var name = CourseNameInput.text;
            var displayName = CourseDisplayNameInput.text;
            var description = CourseDescriptionInput.text;
            var labels = CourseLabelsInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            var modules = CourseModulesInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            var organization = CourseOrganizationInput.text;
            var isDemo = CourseIsDemoToggle.isOn;
            var image = CourseImageInput.text;

            AddCourseInput addCourseInput = new AddCourseInput()
            {
                Name = name,
                DisplayName = displayName,
                Description = description,
                Labels = labels,
                Modules = modules.Length > 0 ? modules : null, // Optional
                Organization = organization,
                IsDemo = isDemo,
                Image = image
            };

            var result = await ARKManager.Content.AddCourseAsync(addCourseInput);

            Debug.Log($"Course Added: {JsonConvert.SerializeObject(result.CourseData)}");
        }
    }
}