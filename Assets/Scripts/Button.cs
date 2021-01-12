using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Menu
{
    //For hooking up the button / will contain references the prefab's components ect
    public class Button : MonoBehaviour
    {
        public Text text;
        public Image background;
        public Button previousBranch;
        public GameObject branch;
        public MenuSet root;

        [ContextMenu("Expand Branch")]
        public void ExpandBranch()
        {
            branch.SetActive(true);
            //Send a message to previous branch to set itself to active...
        }
        public void CloseBranch()
        {
            //Closes the branch.
        }
    }
}