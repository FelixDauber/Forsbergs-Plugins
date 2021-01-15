using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.ListMenuPlugin.Scripts
{
    public class Menu : MonoBehaviour
    {
        #region Variables
        public List<MenuData> menus = new List<MenuData>();
        public List<MenuData> Menus { get => new List<MenuData>(menus); }

        //Events
        [HideInInspector] 
        public UnityEvent<MenuData> onCurrentMenuChange;
        [HideInInspector]
        public UnityEvent<string> playSoundOnClick;

        //Serialized in order to save to new buttons
        [HideInInspector, SerializeField]
        private UnityEvent unityEvent = new UnityEvent();
        #endregion

        #region Public Methods

        public void SetCurrentMenu(string menuName)
        {
            onCurrentMenuChange.Invoke(GetMenu(menuName));
        }

        public void ReturnToRootMenu()
        {
            SetCurrentMenu(menus[0].menuName);
        }

        [ContextMenu("AddMenuButtons")]
        public void AddMenuButtons()
        {
            foreach (var menu in menus)
            {
                if (menus[0].menuName != menu.menuName && menus[0].GetButton(menu.menuName) == null)
                {
                    CreateMenuButton(menu);
                }
            }
        }

        public ButtonData CreateButtonFor(string menuName, string buttonName)
        {
            return GetMenu(menuName).AddButton(buttonName);
        }

        [ContextMenu("NewMenu")]
        public MenuData NewMenu()
        {
            return NewMenu(true);
        }
        public MenuData NewMenu(bool includeBackButton = true)
        {

            unityEvent = new UnityEvent();

            UnityAction action = new UnityAction(ReturnToRootMenu);
            UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(unityEvent, action);

            MenuData newMenu = new MenuData();
            if (includeBackButton)
            {
                ButtonData newButton = newMenu.AddButton("Back");
                newButton.onClick = unityEvent;
            }
            menus.Add(newMenu);
            newMenu.menuName = "Menu ";
            newMenu.menuName += GetMenuIndex(newMenu.menuName);
            return newMenu;
        }
        public MenuData GetMenu(string menuName)
        {
            foreach (var menu in menus)
            {
                if (menu.menuName == menuName)
                {
                    return menu;
                }
            }
            throw new System.Exception($"Error menuData with name: {menuName} does not exist in menu");
        }
        public int GetMenuIndex(string menuName)
        {
            for (int i = 0; i < menus.Count; i++)
            {
                if (menus[i].menuName == menuName)
                {
                    return i;
                }
            }
            throw new System.Exception($"Error menuData with name: {menuName} does not exist in menu");
        }
        public void RemoveMenu(string menuName)
        {
            menus.Remove(GetMenu(menuName));
        }
        #endregion

        #region Private Methods

        void CreateMenuButton(MenuData menu)
        {
            unityEvent = new UnityEvent();
            
            UnityAction<string> action = new UnityAction<string>(SetCurrentMenu);

            UnityEditor.Events.UnityEventTools.AddStringPersistentListener(unityEvent, action, menu.menuName);

            CreateButtonFor(menus[0].menuName, menu.menuName).onClick = unityEvent;
        }
        #endregion
    }

    [CustomEditor(typeof(Menu))]
    public class MenuHolderEditor : Editor
    {
        SerializedProperty menu;
        Menu menuHolderTarget;
        public void OnEnable()
        {
            //menu = serializedObject.targetObject as Menu;
            menuHolderTarget = (target as Menu);
            menu = serializedObject.FindProperty("menus");
        }
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();


            //EditorGUILayout.PropertyField(serializedObject.FindProperty("menu")); //Don't to it like this... /F
            EditorGUILayout.PropertyField(menu);
            serializedObject.ApplyModifiedProperties();

            //serializedObject.Update();

            //DrawMenu(menu as Menu);

            GUILayout.Space(10);
            if (GUILayout.Button("New Menu"))
            {
                if (menuHolderTarget.menus.Count == 0)
                {
                    menuHolderTarget.NewMenu(false);
                }
                else
                {
                    menuHolderTarget.NewMenu();
                }
                EditorUtility.SetDirty(target);
            }
            if (GUILayout.Button("Remove Menu"))
            {
                menuHolderTarget.menus[0].RemoveButton(menuHolderTarget.menus[menuHolderTarget.menus.Count - 1].menuName);
                menuHolderTarget.menus.Remove(menuHolderTarget.menus[menuHolderTarget.menus.Count - 1]);
                EditorUtility.SetDirty(target);
            }
            if(menuHolderTarget.menus.Count > 1)
                if (GUILayout.Button("Add Menu Links To Root"))
                {
                    if (target != null)
                    {
                        menuHolderTarget.AddMenuButtons();
                        EditorUtility.SetDirty(target);
                    }
                }
        }
    }
}