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
        var client = new GraphQLClient("http://vrc.genesiscreations.co:5000/graphql");
        var service = new AuthService(client);
        var controller = new AuthController(service);

        string token = await controller.LoginWithPinCodeAsync("630204");
        await controller.LoginAsync("asasa", "sadfsaf");
        Debug.Log($"Token: {ARKCache.AuthToken}");
        var sessionService = new SessionService(client);
        var sessionController = new SessionController(sessionService);

        var session = await sessionController.GetActiveUserSessionAsync();
        Debug.Log($"Session ID: {ARKCache.Session.Id}");
    }
}