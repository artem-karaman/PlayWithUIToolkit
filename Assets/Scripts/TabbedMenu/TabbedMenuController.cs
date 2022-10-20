using System;
using UnityEngine.UIElements;

namespace TabbedMenu{
    public class TabbedMenuController 
    {
        private const string tabNameSuffix = "Tab";
        private const string contentNameSuffix = "Content";
        private const string tabClassName = "tab";
        private const string currentlySelectedTabClassName = "currentlySelectedTab";
        private const string unselectedContentClassName = "unselectedContent";

        private VisualElement _root;

        public TabbedMenuController(VisualElement root)
        {
            _root = root;
        }

        internal void RegisterTabsCallbacks()
        {
            UQueryBuilder<Label> tabs = GetAllTabs();
            tabs.ForEach((Label tab) => {
                tab.RegisterCallback<ClickEvent>(TabOnClick);
            });
        }

        private void TabOnClick(ClickEvent evt)
        {
            Label clickedTab = evt.currentTarget as Label;
            if (!TabIsCurrentlySelected(clickedTab))
            {
                GetAllTabs().Where(
                    (tab) => tab != clickedTab && TabIsCurrentlySelected(tab)
                ).ForEach(UnselectTab);
                SelectTab(clickedTab);
            }
        }

        private static bool TabIsCurrentlySelected(Label tab)
        {
            return tab.ClassListContains(currentlySelectedTabClassName);
        }

        private void SelectTab(Label tab)
        {
            tab.AddToClassList(currentlySelectedTabClassName);
            VisualElement content = FindContent(tab);
            content.RemoveFromClassList(unselectedContentClassName);
        }

        private void UnselectTab(Label tab)
        {
            tab.RemoveFromClassList(currentlySelectedTabClassName);
            VisualElement content = FindContent(tab);
            content.AddToClassList(unselectedContentClassName);
        }

        private UQueryBuilder<Label> GetAllTabs()
        {
            return _root.Query<Label>(className: tabClassName);
        }

        private VisualElement FindContent(Label tab) => _root.Q(GenerateContentName(tab));

        private static string GenerateContentName(Label tab) => tab.name.Replace(tabNameSuffix, contentNameSuffix);
    }
}


