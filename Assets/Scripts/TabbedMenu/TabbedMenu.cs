using UnityEngine;
using UnityEngine.UIElements;

namespace TabbedMenu{
    public class TabbedMenu : MonoBehaviour
    {
        private TabbedMenuController _tabbedMenuController;
        private const string tabClassName = "tab";
        private const string currentlySelectedTabClassName = "currentlySelectedTab";
        private const string unselectedContentClassName = "unselectedContent";

        void OnEnable()
        {
            UIDocument menu = GetComponent<UIDocument>();
            VisualElement root = menu.rootVisualElement;

            _tabbedMenuController = new(root);
            _tabbedMenuController.RegisterTabsCallbacks();
        }
    }
}

