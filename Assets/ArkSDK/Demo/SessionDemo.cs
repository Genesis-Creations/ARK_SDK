using ARK.SDK.Core;
using ARK.SDK.Models.Session;
using Newtonsoft.Json;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class SessionDemo : MonoBehaviour
    {
        [Header("GetActiveUserSession")]
        public Button GetActiveUserSessionButton;

        [Header("StartUserSession")]
        public Button StartUserSessionButton;

        public TMP_InputField sessionIdInputField;

        [Header("UpdateUserSession")]
        public Button UpdateUserSessionButton;

        private void OnEnable()
        {
            GetActiveUserSessionButton.onClick.AddListener(GetActiveUserSession);
            StartUserSessionButton.onClick.AddListener(StartUserSession);
            UpdateUserSessionButton.onClick.AddListener(UpdateUserSession);
        }

        private void OnDisable()
        {
            GetActiveUserSessionButton.onClick.RemoveListener(GetActiveUserSession);
            StartUserSessionButton.onClick.RemoveListener(StartUserSession);
            UpdateUserSessionButton.onClick.RemoveListener(UpdateUserSession);
        }

        private async void GetActiveUserSession()
        {
            await ARKManager.Session.GetActiveUserSessionAsync();
            Debug.Log($"Session Data : {JsonConvert.SerializeObject(ARKCache.Session)}");
        }

        private async void StartUserSession()
        {
            await ARKManager.Session.StartUserSessionAsync(sessionIdInputField.text);
        }

        [ContextMenu("UpdateUserSession")]
        public async void UpdateUserSession()
        {
            var moduleResultData = new ModuleResultInput
            {
                Id = "module123",
                Duration = 10,
                Interactions = new InteractionResultData[]
    {
        new InteractionResultData
        {
            Id = "interaction123",
            Completed = 1.0f,
            CompletionRatio = 1.0f,
            Compliance = 1.0f,
            ComplianceRatio = 1.0f,
            Duration = 10,
            Score = 100.0f,
            Steps = new List<StepResultData>
            {
                new StepResultData
                {
                    Completed = true,
                    Compliance = true,
                    Title = "Step 1",
                },
                new StepResultData
                {
                    Completed = true,
                    Compliance = true,
                    Title = "Step 2",
                }
            },
            Success = true,
            Total = 100.0f
        }
    },
            };
            var userSessionResultInput = new UserSessionResultInput(moduleResultData);

            if(ARKCache.Session == null || string.IsNullOrEmpty(ARKCache.Session.Id))
            {
                Debug.LogError("Session ID is not available. Please start a session first.");
                return;
            }

            bool result = await ARKManager.Session.UpdateUserSessionAsync(ARKCache.Session.Id, userSessionResultInput);
            Debug.Log($"Update User Session Result: {result}");
        }
    }
}