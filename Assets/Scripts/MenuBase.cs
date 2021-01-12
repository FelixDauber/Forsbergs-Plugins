using UnityEngine;

namespace Menu
{
    public class MenuBase : MonoBehaviour
    {
        public MenuSet menuSet;
        [ContextMenu("Create Menu")] 
        public void CreateMenu()
        {
            
        }
    }
}