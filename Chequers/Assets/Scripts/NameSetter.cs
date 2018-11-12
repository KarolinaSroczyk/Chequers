using UnityEngine;
using UnityEngine.UI;

public class NameSetter : MonoBehaviour {

    bool p1, p2, p3, p4;
    public GameObject textField;

    private void Start()
    {
        p1 = p2 = p3 = p4 = false;
    }
    
    public void SetName(int idx)
    {
        Globals.PlayerNames[idx] = textField.GetComponent<Text>().text;
    }

}
