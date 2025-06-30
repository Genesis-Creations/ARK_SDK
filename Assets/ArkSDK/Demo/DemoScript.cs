using ARK.SDK.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class DemoScript : MonoBehaviour
    {
        [SerializeField] private Button loginButton;

        private void Start()
        {
            loginButton.onClick.AddListener(Login);
        }

        private async void Login()
        {
            //Login with pin code
            await ARKManager.Auth.LoginWithPinCodeAsync("630204");

            //Or Login with email and password
            await ARKManager.Auth.LoginWithMailAndPassowrdAsync("email", "password");

            //AuthToken is cached in ARKCache automatically
            Debug.Log($"Token: {ARKCache.AuthToken}");
        }
    }
}