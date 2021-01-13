using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace ListMenuPlugin
{
    //Temporary so we can see the values.
    public class MenuHolder : MonoBehaviour
    {
        public Menu menu;
        public void SetCurrentMenu(string name)
        {
            menu.SetCurrentMenu(name);
        }
    }
    [CustomEditor(typeof(MenuHolder))]
    public class MenuHolderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GUILayout.Space(10);
            if (GUILayout.Button("Add Menu"))
            {
                (target as MenuHolder).menu.NewMenu();
            }
            if (GUILayout.Button("Remove Menu"))
            {
                (target as MenuHolder).menu.menues.Remove((target as MenuHolder).menu.menues[(target as MenuHolder).menu.menues.Count -1]);
            }
        }
        void DrawMenu(Menu menu)
        {
            foreach (var menuData in menu.menues)
            {
                DrawMenuData(menuData);
            }
        }
        void DrawMenuData(MenuData menuData)
        {
            foreach (var buttonData in menuData.buttons)
            {
                DrawButtonData(buttonData);
            }
        }
        void DrawButtonData(ButtonData buttonData)
        {

        }
    }
}