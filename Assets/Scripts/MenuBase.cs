using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Menu
{
    //The base for the menu, This is the main root of the menu and it decides where the menu is created
    public class MenuBase : MonoBehaviour
    {
        public MenuSet menuSet;
        private List<Button> buttons = new List<Button>();

        //Save buttons to have an easier time calling them later
        //Set up a custom inspector with a single button and the menuSet variable.

        [ContextMenu("Create Menu")]
        public void CreateMenu()
        {
            //Instantiate list
            GameObject newList = Instantiate(menuSet.listPrefab, transform);

            //Instantiate buttons
            foreach (var button in menuSet.buttonData.branchButtons)
            {
                Button newButton = Instantiate(menuSet.buttonPrefab, newList.transform);
                //newButton = 
                //newButton.SetUp(menuSet, previousBranch, button.data, root)
            }
        }
        public void CloseAllBranches()
        {
            //Calls close branch on all buttons
            foreach (var button in buttons)
            {
                button.CloseBranch();
            }
        }
    }

//#if UNITY_EDITOR
//    [CustomEditor(typeof(MenuBase))]
//    public class MenuEditor : Editor
//    {
//        public override void OnInspectorGUI()
//        {
//            DrawDefaultInspector();
//            GUILayout.Space(10);
//            if (GUILayout.Button("CreateMenu"))
//            {
//                (target as MenuBase).CreateMenu();
//            }
//        }
//    }
//#endif
}