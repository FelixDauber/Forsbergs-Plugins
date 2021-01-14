using UnityEngine;
using UnityEngine.UI;

namespace Plugins.ListMenuPlugin.Scripts {
    public class MenuFrame : MonoBehaviour {
        public bool disableImageOnPlay;

        void Start() {
            GetComponent<Image>().enabled = !disableImageOnPlay;
        }
    }
}
