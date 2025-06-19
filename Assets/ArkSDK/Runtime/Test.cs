using ARK.SDK.Controllers.Auth;
using ARK.SDK.Controllers.Session;
using ARK.SDK.Core;
using ARK.SDK.Services.Auth;
using ARK.SDK.Services.Session;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private async void OnButtonClick()
    {
        await ARKManager.Auth.LoginWithPinCodeAsync("630204");
        Debug.Log($"Token: {ARKCache.AuthToken}");

        await ARKManager.Session.GetActiveUserSessionAsync();
        Debug.Log($"Session ID: {ARKCache.Session.Id}");
    }
}