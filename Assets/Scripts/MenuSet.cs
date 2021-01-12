using UnityEngine;

namespace Menu
{
    //Describes how the menu instance is supposed to be laid out. 
    [CreateAssetMenu(fileName = "New Menu Set", menuName = "ScriptableObjects/Plugins/Menu Set")]
    
    public class MenuSet : ScriptableObject
    {
        public Button buttonPrefab;
        public ButtonData buttonData;
    }
}