using UnityEngine;
using UnityEngine.UIElements;

public class SimpleRuntimeUI : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;
    private Button _button;
    private Toggle _toggle;
    private int _clickCount;

    void OnEnable()
    {
        _button = _uiDocument.rootVisualElement.Q<Button>();
        _toggle = _uiDocument.rootVisualElement.Q<Toggle>();

        _button.RegisterCallback<ClickEvent>(PrintClickMessage);
    }

    private void PrintClickMessage(ClickEvent evt)
    {
        ++_clickCount;
        var button = evt.currentTarget as Button;
        Debug.Log($"{button.name} was clicked!" + (_toggle.value ?
                     " Count: " + _clickCount : "")
                );
    }

    void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(PrintClickMessage);
    }
}
