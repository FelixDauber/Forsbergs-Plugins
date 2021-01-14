using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin.Scripts {
    public class MenuSpawner : MonoBehaviour {
        public bool disableImageOnPlay;
        public ButtonObject buttonPrefab;
        List<ButtonObject> currentButtons = new List<ButtonObject>();
        private Menu menuHolder;

        private void Awake()
        {
            menuHolder = GetComponent<Menu>();
        }
        void Start() {
            GetComponent<Image>().enabled = !disableImageOnPlay;
            if (menuHolder.Menus.Count > 0)
            {
                CreateCurrentButtons(menuHolder.Menus[0]);
            }
            menuHolder.onCurrentMenuChange.AddListener(CreateCurrentButtons);
        }

        void OnDestroy() {
            menuHolder.onCurrentMenuChange.RemoveListener(CreateCurrentButtons);
        }

        void CreateCurrentButtons(MenuData menuHolder) {

            if (menuHolder != null) {
                foreach (var button in currentButtons) {
                    Destroy(button.gameObject);
                }
                currentButtons = new List<ButtonObject>();
                CreateButtons(menuHolder);
            }
        }

        void CreateButtons(MenuData menuData) {
            foreach (var buttonData in menuData.buttons) {
                var button = Instantiate(buttonPrefab, transform);
                currentButtons.Add(button);
                var buttonObject = button.GetComponent<ButtonObject>();
                buttonObject.SetUp(buttonData, menuHolder);
            }
        }
    }
}
