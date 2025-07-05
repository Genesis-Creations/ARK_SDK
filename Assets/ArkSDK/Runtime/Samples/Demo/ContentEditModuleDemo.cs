using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class ContentEditModuleDemo : MonoBehaviour
    {
        public TMP_InputField ModuleIdInput;

        public TMP_InputField CourseIdInput;
        public TMP_InputField ModuleNameInput;
        public TMP_InputField ModuleDescriptionInput;
        public TMP_InputField ModuleDisplayNameInput;
        public TMP_InputField ModuleInteractionsInput; // Comma-separated module IDs (optional)
        public Button EditModuleButton;

        private void OnEnable()
        {
            EditModuleButton.onClick.AddListener(EditModule);
        }

        private void OnDisable()
        {
            EditModuleButton.onClick.RemoveListener(EditModule);
        }

        public async void EditModule()
        {
            var moduleId = ModuleIdInput.text; // Module ID to be edited
            var courseId = CourseIdInput.text; // Course ID to which the module will be added
            var name = ModuleNameInput.text;
            var displayName = ModuleDisplayNameInput.text;
            var description = ModuleDescriptionInput.text;
            var interactions = ModuleInteractionsInput.text.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);

            EditModuleInput editModuleInput = new EditModuleInput()
            {
                Id = moduleId, // Required
                CourseId = courseId, // Required
                Name = name,
                DisplayName = displayName,
                Description = description,
                Interactions = interactions.Length > 0 ? interactions : null // Optional
            };

            var result = await ARKManager.Content.EditModuleAsync(editModuleInput);

            Debug.Log($"Module Edited: {JsonConvert.SerializeObject(result.ModuleData)}");
        }
    }
}