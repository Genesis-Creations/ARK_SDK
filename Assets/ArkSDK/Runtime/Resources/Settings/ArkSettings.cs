using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
#endif

//[CreateAssetMenu(fileName = "ArkSettings", menuName = "ARK SDK/ArkSettings", order = 1)]
public class ArkSettings : ScriptableObject
{
    [SerializeField] private string graphqlUrl;

    public  string GraphQLURL
    {
        get => graphqlUrl;
        set
        {
            if (graphqlUrl != value)
            {
                graphqlUrl = value;
            }
        }
    }

#if UNITY_EDITOR
    static ArkSettings _instance;

    // Editor-specific function to fetch or create the settings asset
    public static ArkSettings GetOrCreateSettings()
    {
        // Path to the Resources folder
        string resourcesPath = "Assets/ArkSDK";

        // Check if the Resources folder exists, if not, create it
        if (!Directory.Exists(resourcesPath))
        {
            Directory.CreateDirectory(resourcesPath); // Create Resources folder if it doesn't exist
        }

        // Path to the actual settings asset inside Resources
        string assetPath = "Assets/ArkSDK/ArkSettings.asset";

        // Load the existing asset if it already exists
        ArkSettings settings = AssetDatabase.LoadAssetAtPath<ArkSettings>(assetPath);

        if (settings == null)
        {
            // Create the settings asset if it does not exist
            settings = CreateInstance<ArkSettings>();
            AssetDatabase.CreateAsset(settings, assetPath);
            AssetDatabase.SaveAssets(); // Save the asset to the project
        }

        return settings;
    }
#endif
}
