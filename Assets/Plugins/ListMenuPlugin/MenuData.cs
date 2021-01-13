using System.Collections;
using System.Collections.Generic;
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
                Debug.Log("Adding button for " + menu);
                UnityEvent newEvent = new UnityEvent();
                newEvent.AddListener(delegate { menu.ReturnToRootMenu(); });
                AddButton("Back", newEvent);
            }
        }

        public void AddButton(string name, UnityEvent onClick = null)
        {
            buttons.Add(new ButtonData(name, onClick));
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