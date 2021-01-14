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
        public ButtonData(string name = "New Button")
        {
            buttonName = name;
        }
        //void SetUp(UnityAction onClick, string name)
        //{
        //    UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(this.onClick, onClick); //Event needs to be directly on a unity object? / Cannot save to a temporary unity event?
        //}
    }
}
