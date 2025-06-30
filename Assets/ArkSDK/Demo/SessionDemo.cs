using ARK.SDK.Core;
using Newtonsoft.Json;
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

        private void OnEnable()
        {
            GetActiveUserSessionButton.onClick.AddListener(GetActiveUserSession);
            StartUserSessionButton.onClick.AddListener(StartUserSession);
        }

        private void OnDisable()
        {
            GetActiveUserSessionButton.onClick.RemoveListener(GetActiveUserSession);
            StartUserSessionButton.onClick.RemoveListener(StartUserSession);
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
    }
}