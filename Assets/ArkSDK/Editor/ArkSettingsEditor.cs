using UnityEditor;
using UnityEngine;

public class ArkSettingsEditor : EditorWindow {
    private ArkSettings settings;
    private Editor settingsEditor;

    [MenuItem("Genesis/ArkSDK/Settings")]
    public static void ShowWindow() {
        GetWindow<ArkSettingsEditor>("ArkSettings");
    }
    private void OnEnable() {
        // Load or create the settings SO
        settings = ArkSettings.GetSettings();
        if (settings != null) {
            settingsEditor = Editor.CreateEditor(settings);
            EditorGUIUtility.PingObject(settings);
        }
    }

    private void OnGUI() {
        if (settings == null) {
            EditorGUILayout.HelpBox("ArkSettings asset not found!", MessageType.Error);
            return;
        }
        if (settingsEditor != null) {
            settingsEditor.OnInspectorGUI();
        }

    }
}