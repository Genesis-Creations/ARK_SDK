using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ARKWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Genesis/ARKManager")]
    public static void ShowExample()
    {
        ARKWindow wnd = GetWindow<ARKWindow>();
        wnd.titleContent = new GUIContent("ARK");
    }

    private void OnEnable()
    {
        minSize = new Vector2(500, 300);
        maxSize = new Vector2(1000, 600);
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}