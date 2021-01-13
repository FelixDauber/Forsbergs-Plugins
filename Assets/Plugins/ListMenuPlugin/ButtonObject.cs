using ListMenuPlugin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin {
    public class ButtonObject : MonoBehaviour {
        string buttonName;
        UnityEvent onClick;
        public Text label;

        public void SetUp(ButtonData buttonData, Transform parent) {
            buttonName = buttonData.buttonName;
            label.text = buttonData.buttonName;
            transform.SetParent(parent);
            name = buttonName;
            //TODO hook up onClick event
        }
    }
}
