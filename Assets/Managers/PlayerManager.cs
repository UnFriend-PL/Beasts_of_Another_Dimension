using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();

    internal void AssignTurn(int currentPlayerIdTurn)
    {
        foreach(Player player in players)
        {
            player.myTurn = player.ID == currentPlayerIdTurn;
        }
        //Player player = players.Find(x => x.ID== currentPlayerIdTurn);
        //player.myTurn = true;
    }

    private void Awake()
    {
        instance = this;
    }
}
