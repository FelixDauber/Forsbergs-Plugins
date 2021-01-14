using System.Collections.Generic;
using ListMenuPlugin;
using UnityEngine;

namespace Plugins.ListMenuPlugin {
    public class MenuSpawner : MonoBehaviour {
        public GameObject menuFrame;
        public GameObject buttonPrefab;
        GameObject currentMenuPanel;
        List<GameObject> currentButtons = new List<GameObject>();

        void Start() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.SetCurrentMenu(menu.menus[0].menuName); //TODO set default menu in Menu.cs
            CreateCurrentButtons();
            menu.onCurrentMenuChange.AddListener(CreateCurrentButtons);
        }

        void OnDestroy() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.onCurrentMenuChange.RemoveListener(CreateCurrentButtons);
        }

        void CreateCurrentButtons() {
            var currentMenu = GetComponent<MenuHolder>().menu.currentMenu;

            if (currentMenu != null) {
                foreach (var button in currentButtons) {
                    Destroy(button);
                }
                currentButtons = new List<GameObject>();
                CreateButtons(currentMenu, menuFrame);
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
