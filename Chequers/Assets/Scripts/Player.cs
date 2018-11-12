using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<GameObject> pawns;
    public GameObject PlayerText;
    public bool IsDefeated;
    public bool AiControlled;
    public string Name;
    private bool isActive;
    private Player activePlayer;
    public int pawnsCount;
    public Direction playerDirection;

    public enum Direction {North, East, South, West};

	void Start ()
    {
        IsDefeated = false;
        pawnsCount = 9;
	}

    public void ActivatePlayer(Player player)
    {
        isActive = true;
        activePlayer = player;
    }

    public void DeactivatePlayer()
    {
        isActive = false;
        activePlayer = null;
    }

    public Player GetActivePlayer()
    {
        return activePlayer;
    }

    public void DecreaseCount()
    {
        pawnsCount--;
        if (pawnsCount == 0)
        {
            IsDefeated = true;
        }
    }

    public void SetAi()
    {
        AiControlled = true;
    }

    public void SetName(string name)
    {
        PlayerText.GetComponent<Text>().text = Name = name;
    }
}
