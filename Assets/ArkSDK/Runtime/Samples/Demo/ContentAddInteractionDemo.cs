using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class ContentAddInteractionDemo : MonoBehaviour
    {
        public TMP_InputField ModuleIdInput;

        public TMP_InputField InteractionNameInput;
        public TMP_InputField InteractionDescriptionInput;
        public TMP_InputField InteractionDisplayNameInput;
        public TMP_InputField ModuleDurationInput;
        public TMP_InputField ModuleScoreInput;
        public Button AddInteractionButton;

        private void OnEnable()
        {
            AddInteractionButton.onClick.AddListener(AddInteraction);
        }

        private void OnDisable()
        {
            AddInteractionButton.onClick.RemoveListener(AddInteraction);
        }

        public async void AddInteraction()
        {
            var moduleId = ModuleIdInput.text;
            var name = InteractionNameInput.text;
            var displayName = InteractionDisplayNameInput.text;
            var description = InteractionDescriptionInput.text;
            var duration = ModuleDurationInput.text;
            var score = ModuleScoreInput.text;

            AddInteractionInput addInteractionInput = new AddInteractionInput()
            {
                ModuleId = moduleId,
                Name = name,
                DisplayName = displayName,
                Description = description,
                Duration = string.IsNullOrEmpty(duration) ? 0 : int.Parse(duration),
                Score = string.IsNullOrEmpty(score) ? 0 : int.Parse(score)
            };

            var result = await ARKManager.Content.AddInteractionAsync(addInteractionInput);

            Debug.Log($"Interaction Added: {JsonConvert.SerializeObject(result.InteractionData)}");
        }
    }
}