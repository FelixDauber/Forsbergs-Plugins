using System;
using ListMenuPlugin;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin {
    public class MenuSpawner : MonoBehaviour {
        public GameObject menuPrefab;
        public GameObject buttonPrefab;
        void Start() {
            var menuHolder = GetComponent<MenuHolder>();
            foreach (var menuData in menuHolder.menu.menues) {
                var menu = Instantiate(menuPrefab, transform);
                
                foreach (var buttonData in menuData.buttons) {
                    var button = Instantiate(buttonPrefab, transform);
                    button.transform.SetParent(menu.transform);
                    button.GetComponentInChildren<Text>().text = buttonData.buttonName;
                }
            }
        }
    }
}
