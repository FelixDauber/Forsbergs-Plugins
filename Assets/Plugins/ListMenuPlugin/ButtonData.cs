using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ListMenuPlugin
{
    //Holds information about the button itself
    [System.Serializable]
    public class ButtonData
    {
        public string buttonName;
        public UnityEvent onClick = new UnityEvent();

        //Constructor
        public ButtonData(string name = "New Button", UnityAction onClick = null)
        {
            buttonName = name;
            if (onClick != null)
                this.onClick.AddListener(onClick);
        }
    }
}
