using System;
using System.Collections.Generic;
using ListMenuPlugin;
using UnityEngine;

namespace Plugins.ListMenuPlugin {
    public class MenuSpawner : MonoBehaviour {
        public Transform menuFrame;
        public GameObject menuPanelPrefab;
        public GameObject buttonPrefab;
        GameObject currentMenuPanel;

        void Start() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.SetCurrentMenu(menu.menues[0].menuName);
            CreateCurrentMenu();
            menu.onCurrentMenuChange.AddListener(CreateCurrentMenu);
        }

        void OnDestroy() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.onCurrentMenuChange.RemoveListener(CreateCurrentMenu);
        }

        void Update() {
            ChangeCurrentMenu_InputForTesting();
        }
        
        void CreateCurrentMenu() {
            var currentMenu = GetComponent<MenuHolder>().menu.currentMenu;
            
            if (currentMenu != null) {
                Destroy(currentMenuPanel);
                var menuPanel = CreateMenuPanel(currentMenu);
                currentMenuPanel = menuPanel;
                currentMenuPanel.transform.SetParent(menuFrame);
                CreateButtons(currentMenu, menuPanel);
            }
        }

        GameObject CreateMenuPanel(MenuData menuData) {
            var menuPanel = Instantiate(menuPanelPrefab, transform);
            menuPanel.name = menuData.menuName;
            return menuPanel;
        }

        void CreateButtons(MenuData menuData, GameObject menuPanel) {
            foreach (var buttonData in menuData.buttons) {
                var button = Instantiate(buttonPrefab, transform);
                var buttonObject = button.GetComponent<ButtonObject>();
                buttonObject.SetUp(buttonData, menuPanel.transform);
            }
        }

        void ChangeCurrentMenu_InputForTesting() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                SetCurrentMenu(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                SetCurrentMenu(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                SetCurrentMenu(2);
            }
            
            void SetCurrentMenu(int index) {
                var menu = GetComponent<MenuHolder>().menu;
                menu.SetCurrentMenu(menu.menues[index].menuName);
            }
        }
    }
}
