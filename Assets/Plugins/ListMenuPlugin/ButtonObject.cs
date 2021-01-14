using System;
using ListMenuPlugin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin {
    public class ButtonObject : MonoBehaviour {
        UnityEvent onClick = new UnityEvent();
        public Text label;
        
        public void SetUp(ButtonData buttonData, Transform parent) {
            name = buttonData.buttonName;
            label.text = buttonData.buttonName;
            transform.SetParent(parent);
            
            if (buttonData.onClick != null) {
                onClick = buttonData.onClick;
            }
        }

        public void InvokeOnClick() {
            onClick.Invoke();
        }

        public void PlaySound() {
            GetComponentInParent<MenuHolder>().menu.PlaySound();
        }

        public void DebugButton() {
            Debug.Log(name + ": Clicked");
        }
    }
}
