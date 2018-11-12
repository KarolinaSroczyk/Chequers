using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Kierunek kierunek;
    public List<GameObject> pawns;
    public bool IsDefeated;
    private bool AiControlled;
    private bool isActive;
    private Player activePlayer;
    private int pawnsCount;

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
}
