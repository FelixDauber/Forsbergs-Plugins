using System.Collections;
using System.Collections.Generic;
using Plugins.ListMenuPlugin;
using UnityEngine;
using UnityEngine.Events;

namespace ListMenuPlugin
{
    //Holds the different buttons
    [System.Serializable]
    public class MenuData
    {
        public string menuName;
        public List<ButtonData> buttons = new List<ButtonData>();

        public MenuData(Menu menu = null)
        {
            //Add a return button if this isn't the root menu...
            if (menu != null)
            {
                //Debug.Log("Adding button for " + menu);
                //AddButton("Back", delegate { menu.ReturnToRootMenu(); });
            }
        }

        public ButtonData AddButton(string name)
        {
            ButtonData newButton = new ButtonData(name);
            buttons.Add(newButton);
            return newButton;
        }
        public ButtonData GetButton(string name)
        {
            foreach (var button in buttons)
            {
                if (button.buttonName == name)
                {
                    return button;
                }
            }
            return null;
        }
        public void RemoveButton(string name)
        {
            buttons.Remove(GetButton(name));
        }
        public List<ButtonData> GetButtons()
        {
            return buttons;
        }
    }
}