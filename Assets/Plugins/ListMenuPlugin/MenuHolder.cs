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

        [HideInInspector]
        public UnityEvent unityEvent = new UnityEvent();
        public void SetCurrentMenu(string name)
        {
            menu.SetCurrentMenu(name);
        }
        public void ReturnToRootMenu()
        {
            menu.ReturnToRootMenu();
        }

        [ContextMenu("AddMenuButtons")]
        public void AddMenuButtons()
        {
            foreach (var menu in menu.menues)
            {
                if (this.menu.menues[0].menuName != menu.menuName && this.menu.menues[0].GetButton(menu.menuName) == null)
                {
                    AddButton(menu, this.menu.CreateButtonFor(this.menu.menues[0].menuName, menu.menuName));
                }
            }
        }
        void AddButton(MenuData menu, ButtonData newButton)
        {
            unityEvent = new UnityEvent();
            //UnityAction unityAction = new UnityAction(SetCurrentMenu(menu.menuName));
            //this.menu.menues[0].AddButton(menu.menuName, delegate { SetCurrentMenu(menu.menuName); });

            //Create button
            //ButtonData newButton = this.menu.CreateButtonFor(this.menu.menues[0].menuName, menu.menuName);

            UnityAction<string> action = new UnityAction<string>(SetCurrentMenu);
            Debug.Log(action);
            UnityEditor.Events.UnityEventTools.AddStringPersistentListener(unityEvent, action, menu.menuName);

            //UnityEditor.Events.UnityEventTools.AddObjectPersistentListener(unityEvent, delegate { SetCurrentMenu(menu.menuName); }, gameObject);

            newButton.onClick = unityEvent;
        }
        public ButtonData CreateButtonFor(string menuName, string buttonName)
        {
            return menu.CreateButtonFor(menuName, buttonName);
        }

        public void AddNewMenu()
        {
                        
            unityEvent = new UnityEvent();

            UnityAction action = new UnityAction(ReturnToRootMenu);
            UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(unityEvent, action);

            MenuData newMenu = menu.NewMenu();
            ButtonData newButton = newMenu.AddButton("Back");

            newButton.onClick = unityEvent;
        }
    }

    [CustomEditor(typeof(MenuHolder))]
    public class MenuHolderEditor : Editor
    {
        Menu menu;
        public void OnEnable()
        {
            //menu = serializedObject.targetObject as Menu;
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();


            //EditorGUILayout.PropertyField(serializedObject.FindProperty("menu")); //Don't to it like this... /F
            //EditorGUILayout.PropertyField(menu);

            //serializedObject.Update();

            //DrawMenu(menu as Menu);

            GUILayout.Space(10);
            if (GUILayout.Button("Add Menu"))
            {
                (target as MenuHolder).AddNewMenu();
            }
            if (GUILayout.Button("Remove Menu"))
            {
                (target as MenuHolder).menu.menues.Remove((target as MenuHolder).menu.menues[(target as MenuHolder).menu.menues.Count - 1]);
            }
            if (GUILayout.Button("Add Menu Buttons"))
            {
                if(target != null)
                    (target as MenuHolder).AddMenuButtons();
            }

            serializedObject.ApplyModifiedProperties();
        }
        //void DrawMenu(Menu menu)
        //{
        //    foreach (var menuData in menu.menues)
        //    {
        //        DrawMenuData(menuData);
        //    }
        //}
        //void DrawMenuData(MenuData menuData)
        //{
        //    foreach (var buttonData in menuData.buttons)
        //    {
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("menu")); //Don't to it like this... /F
        //    }
        //}
    }
}