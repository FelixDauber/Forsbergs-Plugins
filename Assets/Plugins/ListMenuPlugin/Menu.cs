using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine.Events;

namespace ListMenuPlugin
{
    //The core of the system, holds the different menues
    [System.Serializable]
    public class Menu
    {
        public MenuData currentMenu;
        public List<MenuData> menus = new List<MenuData>();
        //TODO decide if this Event should be visible in the inspector
        [HideInInspector] public UnityEvent onCurrentMenuChange;

        public void Setup()
        {
            if (menus.Count > 0)
                currentMenu = menus[0];
        }
        public void SetCurrentMenu(string menuName) {
            currentMenu = GetMenu(menuName);
            onCurrentMenuChange.Invoke();
        }
        public void ReturnToRootMenu()
        {
            SetCurrentMenu(menus[0].menuName);
        }

        public MenuData NewMenu()
        {
            //Create new menu
            MenuData newMenu = new MenuData(this);

            //Add to list
            menus.Add(newMenu);

            //Return if needed by exterior scripts
            return newMenu;
        }
        public MenuData GetMenu(string menuName)
        {
            foreach (var menu in menus)
            {
                if (menu.menuName == menuName)
                {
                    return menu;
                }
            }
            throw new System.Exception($"Error menuData with name: {menuName} does not exist in menu");
        }
        public int GetMenuIndex(string menuName)
        {
            return 0;
        }
        public void RemoveMenu(string menuName)
        {
            menus.Remove(GetMenu(menuName));
        }

        public ButtonData CreateButtonFor(string menuName, string buttonName)
        {
            return GetMenu(menuName).AddButton(buttonName);
        }

    }
}