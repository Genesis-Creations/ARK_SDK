using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentEditInteractionDemo : MonoBehaviour
{
    public TMP_InputField InteractionIdInput;

    public TMP_InputField ModuleIdInput;
    public TMP_InputField InteractionNameInput;
    public TMP_InputField InteractionDescriptionInput;
    public TMP_InputField InteractionDisplayNameInput;
    public TMP_InputField ModuleDurationInput;
    public TMP_InputField ModuleScoreInput;
    public Button EditInteractionButton;

    private void OnEnable()
    {
        EditInteractionButton.onClick.AddListener(EditInteraction);
    }

    private void OnDisable()
    {
        EditInteractionButton.onClick.RemoveListener(EditInteraction);
    }

    public async void EditInteraction()
    {
        var interactionId = InteractionIdInput.text;
        var moduleId = ModuleIdInput.text;
        var name = InteractionNameInput.text;
        var displayName = InteractionDisplayNameInput.text;
        var description = InteractionDescriptionInput.text;
        var duration = ModuleDurationInput.text;
        var score = ModuleScoreInput.text;

        EditInteractionInput editInteractionInput = new EditInteractionInput()
        {
            Id = interactionId,
            ModuleId = moduleId,
            Name = name,
            DisplayName = displayName,
            Description = description,
            Duration = string.IsNullOrEmpty(duration) ? 0 : int.Parse(duration),
            Score = string.IsNullOrEmpty(score) ? 0 : int.Parse(score)

        };

        var result = await ARKManager.Content.EditInteractionAsync(editInteractionInput);

        Debug.Log($"Interaction Edited: {JsonConvert.SerializeObject(result.InteractionData)}");
    }
}
