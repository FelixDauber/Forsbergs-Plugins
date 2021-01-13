using System.Collections.Generic;
using ListMenuPlugin;
using UnityEngine;

namespace Plugins.ListMenuPlugin {
    public class MenuSpawner : MonoBehaviour {
        public GameObject menuPanelPrefab;
        public GameObject buttonPrefab;
        public List<GameObject> menus;
        GameObject currentMenuPanel;
        
        void Start() {
            var menu = GetComponent<MenuHolder>().menu;
            menu.SetCurrentMenu(menu.menues[0].menuName);
            CreateCurrentMenu();
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
                CreateButtons(currentMenu, menuPanel);
            }
        }

        GameObject CreateMenuPanel(MenuData menuData) {
            var menuPanel = Instantiate(menuPanelPrefab, transform);
            menuPanel.name = menuData.menuName;
            menus.Add(menuPanel);
            return menuPanel;
        }

        void CreateButtons(MenuData menuData, GameObject menuPanel) {
            foreach (var buttonData in menuData.buttons) {
                var button = Instantiate(buttonPrefab, transform);
                var buttonObject = button.GetComponent<ButtonObject>();
                buttonObject.SetUp(buttonData, menuPanel.transform);
            }
        }
        
        void CreateMenus() {
            var menu = GetComponent<MenuHolder>().menu;
            
            foreach (var menuData in menu.menues) {
                var menuPanel = CreateMenuPanel(menuData);
                CreateButtons(menuData, menuPanel);
            }
        }

        void UpdateMenus() {
            var menu = GetComponent<MenuHolder>().menu;
            foreach (var menuPanel in menus) {
                menuPanel.SetActive(menuPanel.name == menu.currentMenu.menuName);
            }
        }
        
        void ChangeCurrentMenu_InputForTesting() {
            var menu = GetComponent<MenuHolder>().menu;

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
                menu.SetCurrentMenu(menu.menues[index].menuName);
                CreateCurrentMenu();
            }
        }
    }
}
