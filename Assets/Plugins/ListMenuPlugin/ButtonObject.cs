using System;
using ListMenuPlugin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin {
    public class ButtonObject : MonoBehaviour {
        string buttonName;
        public UnityEvent onClick = new UnityEvent();
        public Text label;
        
        public void SetUp(ButtonData buttonData, Transform parent) {
            buttonName = buttonData.buttonName;
            label.text = buttonData.buttonName;
            
            if (buttonData.onClick != null) {
                onClick = buttonData.onClick;
                GetComponent<Button>().onClick = onClick as Button.ButtonClickedEvent;
                //GetComponent<Button>().onClick.AddListener(DebugEvent);
            }
            transform.SetParent(parent);
            name = buttonName;
        }

        public void invokeOnClick() {
            onClick.Invoke();
        }

        void Start() {
            onClick?.AddListener(DebugEvent);
        }

        void DebugEvent() {
            Debug.Log("onClick invoked");
        }
    }
}
