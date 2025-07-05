using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class ContentAddModuleDemo : MonoBehaviour
    {
        public TMP_InputField CourseIdInput;

        public TMP_InputField ModuleNameInput;
        public TMP_InputField ModuleDescriptionInput;
        public TMP_InputField ModuleDisplayNameInput;
        public TMP_InputField ModuleInteractionsInput; // Comma-separated module IDs (optional)
        public Button AddModuleButton;

        private void OnEnable()
        {
            AddModuleButton.onClick.AddListener(AddModule);
        }

        private void OnDisable()
        {
            AddModuleButton.onClick.RemoveListener(AddModule);
        }

        public async void AddModule()
        {
            var courseId = CourseIdInput.text; // Course ID to which the module will be added
            var name = ModuleNameInput.text;
            var displayName = ModuleDisplayNameInput.text;
            var description = ModuleDescriptionInput.text;
            var interactions = ModuleInteractionsInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);

            AddModuleInput addModuleInput = new AddModuleInput()
            {
                CourseId = courseId, // Required
                Name = name,
                DisplayName = displayName,
                Description = description,
                Interactions = interactions.Length > 0 ? interactions : null // Optional
            };

            var result = await ARKManager.Content.AddModuleAsync(addModuleInput);

            Debug.Log($"Module Added: {JsonConvert.SerializeObject(result.ModuleData)}");
        }
    }
}