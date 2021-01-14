using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.ListMenuPlugin.Scripts
{
    //The core of the system, holds the different menues
    [System.Serializable]
    public class Menu
    {
        public List<MenuData> menus = new List<MenuData>();
        //TODO decide if this Event should be visible in the inspector
        [HideInInspector] public UnityEvent<MenuData> onCurrentMenuChange;
        [HideInInspector] public UnityEvent<string> onButtonClick;

        public void PlaySound(string soundName = "")
        {
            onButtonClick.Invoke("ButtonSound");
        }

        public void Setup()
        {
            onCurrentMenuChange.Invoke(menus[0]);
        }
        public void SetCurrentMenu(string menuName) {
            onCurrentMenuChange.Invoke(GetMenu(menuName));
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
            for(int i = 0; i < menus.Count; i++)
            {            
                if (menus[i].menuName == menuName)
                {
                    return i;
                }
            }
            throw new System.Exception($"Error menuData with name: {menuName} does not exist in menu");
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