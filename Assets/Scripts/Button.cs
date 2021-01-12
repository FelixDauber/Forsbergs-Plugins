using Menu;
using UnityEngine;
using UnityEngine.UI;

//For hooking up the button / will contain references the prefab's components ect
public class Button : MonoBehaviour {
    public Text label;
    public Image background;
    Button previousBranch;
    GameObject branch;
    MenuBase root;

    public void SetUp(string label, Button previousBranch, GameObject branch, MenuBase root) {
        this.label.text = label;
        this.previousBranch = previousBranch;
        this.branch = branch;
        this.root = root;
    }
    
    public void CreateBranch() {
        
    }
    
    [ContextMenu("Expand Branch")]
    public void ExpandBranch() {
        //Tell previous branch to set itself to active
        previousBranch.ExpandBranch();
        if (branch != null)
            branch.SetActive(true);
    }
    
    public void CloseBranch() {
        branch.SetActive(false);
    }
}