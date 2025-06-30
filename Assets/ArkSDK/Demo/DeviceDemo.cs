using ARK.SDK.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeviceDemo : MonoBehaviour
{
    [Header("CheckDeviceId")]
    public Button CheckDeviceIdButton;

    public TMP_InputField deviceIdField;

    private void OnEnable()
    {
        CheckDeviceIdButton.onClick.AddListener(CheckDeviceId);
    }

    private void OnDisable()
    {
        CheckDeviceIdButton.onClick.RemoveListener(CheckDeviceId);
    }

    private async void CheckDeviceId()
    {
        var response = await ARKManager.Device.CheckDeviceIdAsync(deviceIdField.text);
        Debug.Log($"CheckDeviceId : {response.CheckDeviceId}");
    }
}