using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ListMenuPlugin
{
    //The core of the system, holds the different menues
    [System.Serializable]
    public class Menu
    {
        public MenuData currentMenu;
        public List<MenuData> menues = new List<MenuData>();

        public void Setup()
        {
            if (menues.Count > 0)
                currentMenu = menues[0];
        }
        public void SetCurrentMenu(string menuName)
        {
            currentMenu = GetMenu(menuName);
        }
        public void ReturnToRootMenu()
        {
            currentMenu = menues[0];
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
    }
}