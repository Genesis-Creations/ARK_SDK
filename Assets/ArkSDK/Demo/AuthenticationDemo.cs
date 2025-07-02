using ARK.SDK.Core;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class AuthenticationDemo : MonoBehaviour
    {
        [Header("LoginWithMailAndPassword")]
        public Button loginWithEmailAndPasswordButton;

        public TMP_InputField emailInputField;
        public TMP_InputField passwordInputField;

        [Header("LoginWithPincode")]
        public Button loginWithPincodeButton;

        public TMP_InputField pinCodeInputField;

        private void OnEnable()
        {
            loginWithEmailAndPasswordButton.onClick.AddListener(LoginWithEmailAndPassword);
            loginWithPincodeButton.onClick.AddListener(LoginWithPinCode);
        }

        private void OnDisable()
        {
            loginWithEmailAndPasswordButton.onClick.RemoveListener(LoginWithEmailAndPassword);
            loginWithPincodeButton.onClick.RemoveListener(LoginWithPinCode);
        }

        private async void LoginWithPinCode()
        {
            await ARKManager.Auth.LoginWithPinCodeAsync(pinCodeInputField.text);
            Debug.Log($"Auth Token : {JsonConvert.SerializeObject(ARKCache.Auth)}");
        }

        private async void LoginWithEmailAndPassword()
        {
            await ARKManager.Auth.LoginWithMailAndPassowrdAsync(emailInputField.text, passwordInputField.text);
            Debug.Log($"Auth Token : {JsonConvert.SerializeObject(ARKCache.Auth)}");
        }
    }
}