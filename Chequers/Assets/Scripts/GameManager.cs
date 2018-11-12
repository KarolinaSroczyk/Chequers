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
        for(int i = 0;i<=3;i++)
        {
            Players[i].name = Globals.PlayerNames[i];
            Debug.Log(Players[i].name);
        }
        AssignAi(Globals.PlayersCount);
	    if(Players.Length > 0)
        {
            activePlayer = Players[activeIndex];
        }
	}

    private void AssignAi(int players)
    {
        switch(players)
        {
            case 1:
                Players[1].SetAi();
                Players[2].SetAi();
                Players[3].SetAi();
                break;
            case 2:
                Players[1].SetAi();
                Players[3].SetAi();
                break;
            case 3:
                Players[3].SetAi();
                break;
            case 4:
            default:
                break;
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
            float dist = Vector2.Distance(hit.collider.transform.position, lastGameObject.transform.position);
            Vector3 position = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            if (dist<1.2f)
            {
                lastGameObject.transform.position = position;
                activePlayer.DeactivatePlayer();
                do
                {
                    activeIndex = (activeIndex + 1) % 4;
                } while (Players[activeIndex].IsDefeated);
                activePlayer.ActivatePlayer(Players[activeIndex]);
                activePlayer = activePlayer.GetActivePlayer();
            }
            else if(Mathf.Abs(dist-2.1f) < 0.1f)
            {
                RaycastHit2D hit2 = Physics2D.Raycast((lastGameObject.transform.position + position)/2f, Vector2.zero);
                if (hit2.collider && hit2.collider.transform.parent.GetComponent<Player>() && !hit2.collider.transform.parent.name.Equals(activePlayer.name))
                {
                    hit2.collider.transform.parent.gameObject.GetComponent<Player>().DecreaseCount();
                    hit2.collider.gameObject.SetActive(false);
                    Jump(position);
                }   
            }
        }
    }

    private void Jump(Vector2 position)
    {
        lastGameObject.transform.position = position;
        if(!CheckForNextJump(position))
        {//mozna skoczyc
            activePlayer.DeactivatePlayer();
            do
            {
                activeIndex = (activeIndex + 1) % 4;
            } while (Players[activeIndex].IsDefeated);
            activePlayer.ActivatePlayer(Players[activeIndex]);
            activePlayer = activePlayer.GetActivePlayer();
        }
    }

    private bool CheckForNextJump(Vector2 position)
    {
        float positionOffset = 1.5f;
        Vector2 neighbourPosition = Vector2.zero;
        Vector2 jumpPosition = Vector2.zero;
        for (int i = -1; i <= 1; i+=2)
        {
            for(int j = -1; j <=1; j+=2)
            {
                jumpPosition = new Vector2(position.x + positionOffset * i, position.y + positionOffset * j);
                neighbourPosition = new Vector2(position.x + positionOffset/2f * i, position.y + positionOffset/2f * j);
                RaycastHit2D hit = Physics2D.Raycast(neighbourPosition, Vector2.zero);
                RaycastHit2D hitJump = Physics2D.Raycast(jumpPosition, Vector2.zero);
                bool condition1 = hit.collider && hit.collider.transform.parent.GetComponent<Player>() && !hit.collider.transform.parent.name.Equals(activePlayer.name);
                bool condition2 = hitJump.collider != null && hitJump.collider.transform.parent.name.Equals("Fields");
                if (condition1 && condition2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
