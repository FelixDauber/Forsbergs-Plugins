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
    }
    [CustomEditor(typeof(MenuHolder))]
    public class MenuHolderEditor : Editor
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
}