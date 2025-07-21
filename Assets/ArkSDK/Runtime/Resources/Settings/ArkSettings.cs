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
        string resourcesPath = "Assets/ArkSDK/Runtime/Resources";
        if (!Directory.Exists(resourcesPath))
        {
            Directory.CreateDirectory(resourcesPath);
        }
        // Path to the actual settings asset inside Resources
        string assetPath = "Assets/ArkSDK/Runtime/Resources/ArkSettings.asset";
        // Try to load the asset from the AssetDatabase
        ArkSettings settings = AssetDatabase.LoadAssetAtPath<ArkSettings>(assetPath);
        if (settings == null)
        {
            // Create the settings asset if it does not exist
            settings = CreateInstance<ArkSettings>();
            AssetDatabase.CreateAsset(settings, assetPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }
#else
    public static ArkSettings GetOrCreateSettings()
    {
        // At runtime, load from Resources (Resources.Load uses path relative to Resources folder, no extension)
        ArkSettings settings = Resources.Load<ArkSettings>("ArkSettings");
        if (settings == null)
        {
            Debug.LogError("ArkSettings asset not found in Resources. Please create it in the Editor at Assets/ArkSDK/Resources/ArkSettings.asset");
        }
        return settings;
    }
#endif
}
