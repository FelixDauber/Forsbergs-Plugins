using System.Collections.Generic;
using UnityEngine;

namespace Plugins.ListMenuPlugin.Scripts {
    public class MenuSpawner : MonoBehaviour {
        public GameObject menuFrame;
        public GameObject buttonPrefab;
        List<GameObject> currentButtons = new List<GameObject>();

        void Start() {
            var menu = GetComponent<MenuHolder>().menu;
            CreateCurrentButtons(menu.menus[0]);
            menu.onCurrentMenuChange.AddListener(CreateCurrentButtons);
        }

        void OnDestroy() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.onCurrentMenuChange.RemoveListener(CreateCurrentButtons);
        }

        void CreateCurrentButtons(MenuData menuHolder) {

            if (menuHolder != null) {
                foreach (var button in currentButtons) {
                    Destroy(button);
                }
                currentButtons = new List<GameObject>();
                CreateButtons(menuHolder, menuFrame);
            }
        }

        void CreateButtons(MenuData menuData, GameObject menuFrame) {
            foreach (var buttonData in menuData.buttons) {
                var button = Instantiate(buttonPrefab, transform);
                currentButtons.Add(button);
                var buttonObject = button.GetComponent<ButtonObject>();
                buttonObject.SetUp(buttonData, menuFrame.transform);
            }
        }
    }
}
