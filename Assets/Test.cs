using ARK.SDK.Controllers;
using ARK.SDK.Core;
using ARK.SDK.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Button button;
    private AuthService authService;
    public TextMeshProUGUI resultText;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private async void OnButtonClick()
    {
        var client = new GraphQLClient("https://ark.genesiscreations.co/graphql");
        var service = new AuthService(client);
        var controller = new AuthController(service);

        string token = await controller.Login("jumeriah@genesiscreations.co", "Test12345");
        client.SetAuthToken(token);

        Debug.Log($"Token: {token}");
    }
}