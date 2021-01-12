using UnityEngine;

namespace Menu
{
    [CreateAssetMenu(fileName = "New Menu Set", menuName = "ScriptableObjects/Plugins/Menu Set")]
    
    public class MenuSet : ScriptableObject
    {
        public ButtonData buttonData;
    }
}