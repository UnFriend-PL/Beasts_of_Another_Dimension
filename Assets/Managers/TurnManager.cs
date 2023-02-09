using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentPlayerIdTurn;
    public static TurnManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartTurnGameplay(int playerID)
    {
        currentPlayerIdTurn= playerID;
        PlayerManager.instance.AssignTurn(currentPlayerIdTurn);
    }

    public void StartTurn()
    {

    }

    public void EndTurn()
    {

    }
}
