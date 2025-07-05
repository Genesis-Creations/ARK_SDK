using UnityEditor;
using UnityEngine;

public class ArkSettingsEditor : EditorWindow
{
    private ArkSettings settings;

    [MenuItem("Genesis/ArkSDK/Settings")]
    public static void ShowWindow()
    {
        GetWindow<ArkSettingsEditor>("Settings");
    }

    private void OnGUI()
    {
        if (settings == null)
        {
            settings = ArkSettings.GetOrCreateSettings();
        }

        // Display settings fields
        settings.GraphQLURL = EditorGUILayout.TextField("GraphQL URL", settings.GraphQLURL);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
        }
    }
}
