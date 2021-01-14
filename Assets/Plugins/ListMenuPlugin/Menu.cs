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
        public List<MenuData> menues = new List<MenuData>();
        //TODO decide if this Event should be visible in the inspector
        [HideInInspector] public UnityEvent onCurrentMenuChange;

        public void Setup()
        {
            if (menues.Count > 0)
                currentMenu = menues[0];
        }
        public void SetCurrentMenu(string menuName) {
            currentMenu = GetMenu(menuName);
            onCurrentMenuChange.Invoke();
        }
        public void ReturnToRootMenu()
        {
            SetCurrentMenu(menues[0].menuName);
        }

        public MenuData NewMenu()
        {
            //Create new menu
            MenuData newMenu = new MenuData(this);

            //Add to list
            menues.Add(newMenu);

            //Return if needed by exterior scripts
            return newMenu;
        }
        public MenuData GetMenu(string menuName)
        {
            foreach (var menu in menues)
            {
                if (menu.menuName == menuName)
                {
                    return menu;
                }
            }
            throw new System.Exception($"Error menuData with name: {menuName} does not exist in menu");
        }
        public void RemoveMenu(string menuName)
        {
            menues.Remove(GetMenu(menuName));
        }

        public ButtonData CreateButtonFor(string menuName, string buttonName)
        {
            return GetMenu(menuName).AddButton(buttonName);
        }
    }
}