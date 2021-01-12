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

        public void AddButton(string name, UnityAction onClick = null)
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