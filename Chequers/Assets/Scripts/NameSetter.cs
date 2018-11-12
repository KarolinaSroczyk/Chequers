using UnityEngine;

public class NameSetter : MonoBehaviour {

    bool p1, p2, p3, p4;
    string name = "";

    private void Start()
    {
        p1 = p2 = p3 = p4 = false;
    }
    private void OnGUI()
    {
        var screenWidth = Screen.currentResolution.width;
        var screenHeight = Screen.currentResolution.height;
        var textWidth = 200f;

        GUI.Label(new Rect(screenWidth/2f-textWidth, 0, textWidth, 100), "Player names");

        if(p1)
        {
            name = GUI.TextField(new Rect(screenWidth / 2f - textWidth, 250f, 2 * textWidth, 25), name);
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 280f, 2 * textWidth, 25), "Apply"))
            {
                Globals.PlayerNames[0] = name;
                p1 = false;
            }
        }
        else
        {
            if(GUI.Button(new Rect(screenWidth / 2f - textWidth, 250f, 2 * textWidth, 25), "Click to Set Player1 name"))
            {
                p1 = true;
                p2 = p3 = p4 = false;
                name = "";
            }
        }
        if(p2)
        {
            name = GUI.TextField(new Rect(screenWidth / 2f - textWidth, 320f, 2 * textWidth, 25), name);
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 350f, 2 * textWidth, 25), "Apply"))
            {
                Globals.PlayerNames[1] = name;
                p2 = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 320f, 2 * textWidth, 25), "Click to Set Player2 name"))
            {
                p2 = true;
                p1 = p3 = p4 = false;
                name = "";
            }
        }
        
        if(p3)
        {
            name = GUI.TextField(new Rect(screenWidth / 2f - textWidth, 390f, 2 * textWidth, 25), name);
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 420f, 2 * textWidth, 25), "Apply"))
            {
                Globals.PlayerNames[2] = name;
                p3 = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 390f, 2 * textWidth, 25), "Click to Set Player3 name"))
            {
                p3 = true;
                p1 = p2 = p4 = false;
                name = "";
            }
        }
        
        if(p4)
        {
            name = GUI.TextField(new Rect(screenWidth / 2f - textWidth, 460f, 2 * textWidth, 25), name);
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 490f, 2 * textWidth, 25), "Apply"))
            {
                Globals.PlayerNames[3] = name;
                p4 = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(screenWidth / 2f - textWidth, 460f, 2 * textWidth, 25), "Click to Set Player4 name"))
            {
                p4 = true;
                p1 = p2 = p3 = false;
                name = "";
            }
        }   
    }
}
