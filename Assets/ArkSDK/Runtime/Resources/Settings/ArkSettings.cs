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
}
