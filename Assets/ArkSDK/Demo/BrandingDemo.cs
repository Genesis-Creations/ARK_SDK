using ARK.SDK.Core;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Demo
{
    public class BrandingDemo : MonoBehaviour
    {
        [Header("GetBranding")]
        public Button getBrandingButton;

        private void OnEnable()
        {
            getBrandingButton.onClick.AddListener(GetBranding);
        }

        private void OnDisable()
        {
            getBrandingButton.onClick.RemoveListener(GetBranding);
        }

        private async void GetBranding()
        {
            var response = await ARKManager.Branding.GetBrandingAsync();
            Debug.Log($"Branding : {JsonConvert.SerializeObject(response.Branding)}");
        }
    }
}