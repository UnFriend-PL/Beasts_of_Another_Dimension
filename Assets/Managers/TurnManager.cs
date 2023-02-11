using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentPlayerIdTurn;
    public static TurnManager instance;

    public void Start()
    {
        StartTurnGameplay(GameConfig.Player2ID);
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartTurnGameplay(int playerID)
    {
        currentPlayerIdTurn = playerID;
        CharacterManager.instance.AssignTurn(currentPlayerIdTurn);
        StartTurn();
    }

    public void StartTurn()
    {
        GameController.instance.UpdateCurrentPlayerTurn(currentPlayerIdTurn, CharacterManager.instance.GetPlayerName(currentPlayerIdTurn).name);
        CharacterManager.instance.AssignTurn(currentPlayerIdTurn);

    }

    public void EndTurn()
    {
        currentPlayerIdTurn = currentPlayerIdTurn ==  GameConfig.Player1ID ? GameConfig.Player2ID : GameConfig.Player1ID;
        StartTurn();
    }
}
