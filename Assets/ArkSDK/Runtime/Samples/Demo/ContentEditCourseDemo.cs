using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class ContentEditCourseDemo : MonoBehaviour
    {
        public TMP_InputField CourseIdInput;

        public TMP_InputField CourseNameInput;
        public TMP_InputField CourseDescriptionInput;
        public TMP_InputField CourseDisplayNameInput;
        public TMP_InputField CourseLabelsInput; // Comma-separated labels
        public TMP_InputField CourseModulesInput; // Comma-separated module IDs (optional)
        public TMP_InputField CourseOrganizationInput; // Organization ID
        public Toggle CourseIsDemoToggle; // True or False
        public TMP_InputField CourseImageInput;
        public Button EditCourseButton;

        private void OnEnable()
        {
            EditCourseButton.onClick.AddListener(EditCourse);
        }
        private void OnDisable()
        {
            EditCourseButton.onClick.RemoveListener(EditCourse);
        }

        public async void EditCourse()
        {
            var id = CourseIdInput.text; // Course ID to edit
            var name = CourseNameInput.text;
            var displayName = CourseDisplayNameInput.text;
            var description = CourseDescriptionInput.text;
            var labels = CourseLabelsInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            var modules = CourseModulesInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            var organization = CourseOrganizationInput.text;
            var isDemo = CourseIsDemoToggle.isOn;
            var image = CourseImageInput.text;

            EditCourseInput editCourseInput = new EditCourseInput()
            {
                Id = id,
                Name = name,
                DisplayName = displayName,
                Description = description,
                Labels = labels,
                Modules = modules.Length > 0 ? modules : null, // Optional
                Organization = organization,
                IsDemo = isDemo,
                Image = image
            };

            var result = await ARKManager.Content.EditCourseAsync(editCourseInput);

            Debug.Log($"Course Edited: {JsonConvert.SerializeObject(result.CourseData)}");
        }
    }
}