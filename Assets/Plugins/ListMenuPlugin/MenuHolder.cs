using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace ListMenuPlugin
{
    public class MenuHolder : MonoBehaviour
    {
        public MenuData menuData;
    }
    [CustomEditor(typeof(MenuHolder))]
    public class MenuEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            //GUILayout.Space(10);
            //if (GUILayout.Button("AddButton"))
            //{
            //    (target as Menu).CreateMenu();
            //}
        }
    }

    [System.Serializable]
    public class MenuData
    {
        public List<ButtonData> buttons = new List<ButtonData>();

        public void AddButton(string name, UnityAction onClick)
        {
            buttons.Add(new ButtonData(name, onClick));
        }
        public ButtonData GetButton(string name)
        {
            foreach (var button in buttons)
            {
                if(button.buttonName == name)
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
    }

    [System.Serializable]
    public class ButtonData
    {
        public string buttonName;
        public UnityEvent onClick;

        public ButtonData(string name)
        {
            buttonName = name;
        }
        public ButtonData(string name, UnityAction onClick)
        {
            buttonName = name;
            this.onClick.AddListener(onClick);
        }
    }
}