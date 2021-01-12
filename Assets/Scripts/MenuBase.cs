using UnityEngine;

namespace Menu
{
    //The base for the menu, This is the main root of the menu and it decides where the menu is created
    public class MenuBase : MonoBehaviour
    {
        public MenuSet menuSet;

        //Save buttons to have an easier time calling them later
        //Set up a custom inspector with a single button and the menuSet variable.

        [ContextMenu("Create Menu")]
        public void CreateMenu()
        {
            //Sets up the buttons, use the MenuSet as a blueprint
        }
        public void CloseAllBranches()
        {
            //Calls close branch on all buttons
        }
    }
}