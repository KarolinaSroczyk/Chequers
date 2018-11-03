using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    public Kierunek kierunek;
    public List<GameObject> pawns;
    private bool isActive;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivatePlayer()
    {
        isActive = false;
    }

    public void DeactivatePlayer()
    {
        isActive = true;
    }
}
