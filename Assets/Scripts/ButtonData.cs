using UnityEngine.Events;

namespace Menu
{
    [System.Serializable] 
    public class ButtonData
    {
        public string name;
        public ButtonData[] branchButtons;
        public UnityEvent onButtonClick;
    }
}