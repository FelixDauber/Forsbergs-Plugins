using System.Collections.Generic;

namespace Plugins.ListMenuPlugin.Scripts
{
    //Holds the different buttons
    [System.Serializable]
    public class MenuData
    {
        public string menuName;
        public List<ButtonData> buttons = new List<ButtonData>();

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