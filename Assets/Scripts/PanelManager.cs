using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument  _mainMenuScreen;

    void OnEnable()
    {
        var root = _mainMenuScreen.rootVisualElement;
        var startButton = root.Q<Button>("start-button");
        if (startButton != null)
        {
            startButton.clickable.clicked += OnStartButtonClicked;
        }
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("Start button was clicked");
    }
}
