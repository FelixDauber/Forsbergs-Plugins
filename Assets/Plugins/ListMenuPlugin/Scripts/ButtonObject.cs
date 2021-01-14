using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin.Scripts {
    public class ButtonObject : MonoBehaviour {
        UnityEvent onClick = new UnityEvent();
        public Text label;
        Menu menu;
        
        public void SetUp(ButtonData buttonData, Menu menuHolder) {
            name = buttonData.buttonName;
            label.text = name;
            menu = menuHolder;

            if (buttonData.onClick != null) {
                onClick = buttonData.onClick;
            }
            GetComponent<Button>().onClick.AddListener(InvokeOnClick);
        }

        public void InvokeOnClick() {
            onClick.Invoke();
            menu.playSoundOnClick.Invoke("ButtonSound");
        }

        public void PlaySound() {
            //TODO Fix This: GetComponentInParent<Menu>().PlaySound();
        }

        public void DebugButton() {
            Debug.Log(name + ": Clicked");
        }
    }
}
