using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.ListMenuPlugin.Scripts
{
    public class MenuHolder : MonoBehaviour
    {
        public Menu menu;
        [HideInInspector]
        public UnityEvent unityEvent = new UnityEvent();

        void Awake() {
            var menuName = menu.menus[0].menuName;
            SetCurrentMenu(menuName);
        }

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
            foreach (var menu in menu.menus)
            {
                if (this.menu.menus[0].menuName != menu.menuName && this.menu.menus[0].GetButton(menu.menuName) == null)
                {
                    AddButton(menu, this.menu.CreateButtonFor(this.menu.menus[0].menuName, menu.menuName));
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
            //Debug.Log(action);
            UnityEditor.Events.UnityEventTools.AddStringPersistentListener(unityEvent, action, menu.menuName);

            //UnityEditor.Events.UnityEventTools.AddObjectPersistentListener(unityEvent, delegate { SetCurrentMenu(menu.menuName); }, gameObject);

            newButton.onClick = unityEvent;
        }
        public ButtonData CreateButtonFor(string menuName, string buttonName)
        {
            return menu.CreateButtonFor(menuName, buttonName);
        }

        public MenuData AddNewMenu(bool includeBackButton = true)
        {
                        
            unityEvent = new UnityEvent();

            UnityAction action = new UnityAction(ReturnToRootMenu);
            UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(unityEvent, action);

            MenuData newMenu = menu.NewMenu();
            ButtonData newButton = newMenu.AddButton("Back");

            newButton.onClick = unityEvent;
            return newMenu;
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

            MenuHolder menuHolderTarget = (target as MenuHolder);

            //EditorGUILayout.PropertyField(serializedObject.FindProperty("menu")); //Don't to it like this... /F
            //EditorGUILayout.PropertyField(menu);

            //serializedObject.Update();

            //DrawMenu(menu as Menu);

            GUILayout.Space(10);
            if (GUILayout.Button("Add Menu"))
            {
                MenuData newMenu;
                if (menuHolderTarget.menu.menus.Count == 0)
                {
                    newMenu = menuHolderTarget.AddNewMenu(false);
                }
                else
                {
                    newMenu = menuHolderTarget.AddNewMenu();
                }
                newMenu.menuName = "Menu ";
                newMenu.menuName += menuHolderTarget.menu.GetMenuIndex(newMenu.menuName);
            }
            if (GUILayout.Button("Remove Menu"))
            {
                menuHolderTarget.menu.menus[0].RemoveButton(menuHolderTarget.menu.menus[menuHolderTarget.menu.menus.Count - 1].menuName);
                menuHolderTarget.menu.menus.Remove(menuHolderTarget.menu.menus[menuHolderTarget.menu.menus.Count - 1]);
            }
            if(menuHolderTarget.menu.menus.Count > 1)
                if (GUILayout.Button("Add Menu Links To Root"))
                {
                    if(target != null)
                        menuHolderTarget.AddMenuButtons();
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