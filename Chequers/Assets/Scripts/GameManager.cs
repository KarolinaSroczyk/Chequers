using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Sprite ActivePawn;
    private Sprite lastSprite;
    private GameObject lastGameObject;
    private bool moveEnabled;
    private int activeIndex;
    public Player[] Players;
    private Player activePlayer;
	// Use this for initialization
	void Start ()
    {
        activeIndex = 0;
	    if(Players.Length > 0)
        {
            activePlayer = Players[activeIndex];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            if (moveEnabled)
            {
                Move();
            }
            SetPawn();
        }
	}

    public void SetPawn()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null && !hit.collider.transform.parent.name.Equals("Fields"))
        {
            if(lastGameObject != null)
            {
                lastGameObject.GetComponent<SpriteRenderer>().sprite = lastSprite;
            }
            if(hit.collider.transform.parent.name.Equals(activePlayer.name))
            {
                GameObject gameObject = hit.collider.gameObject;
                lastGameObject = gameObject;
                lastSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                gameObject.GetComponent<SpriteRenderer>().sprite = ActivePawn;
                moveEnabled = true;
            }
        }
        else
        {
            if (lastGameObject != null)
            {
                lastGameObject.GetComponent<SpriteRenderer>().sprite = lastSprite;
                lastGameObject = null;
            }
            moveEnabled = false;
        }
    }

    private void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(!lastGameObject.transform.parent.name.Equals(activePlayer.name))
        {
            return;
        }
        if (hit.collider != null && hit.collider.transform.parent.name.Equals("Fields"))
        {
            if(Vector2.Distance(hit.collider.transform.position, lastGameObject.transform.position)<1.2f)
            {
                lastGameObject.transform.position = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                activePlayer.DeactivatePlayer();
                activeIndex = activeIndex == 3 ? activeIndex = 0 : activeIndex + 1;
                activePlayer = Players[activeIndex];
            }
        }
    }

}
