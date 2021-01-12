using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}