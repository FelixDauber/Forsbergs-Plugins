using UnityEngine.Events;

namespace Menu
{
    //Button data is for sharing data between scripts, Anything inside this is a describer of what this button is.
    [System.Serializable] 
    public class ButtonData
    {
        public string name;
        public ButtonData[] branchButtons;
        //public UnityEvent onButtonClick;
    }
}