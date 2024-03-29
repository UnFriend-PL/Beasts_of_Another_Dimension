using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

[System.Serializable]
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public GameObject characterPrefab;
    public List<CharacterDisplay> characters = new List<CharacterDisplay>();
    public List<Player> players = new List<Player>();

    internal void AssignTurn(int currentPlayerIdTurn)
    {
        foreach(Player player in players)
        {
            player.myTurn = player.ID == currentPlayerIdTurn;
            // dodac system many tutaj
        }
        //Player player = players.Find(x => x.ID== currentPlayerIdTurn);
        //player.myTurn = true;
    }

    public Player GetPlayerName(int playerID)
    {
        foreach(var player in players) {
            if(player.ID == playerID)
            {
                return player;
            }
        }
        throw new Exception("Player not Found.");
    }

    private void Awake()
    {
        instance = this;


        Player p0, p1;
        int id1=1, id2=2;
        p0 = new Player(10, id1, "szymon");
        //p0.myTurn = true;
        GameConfig.Player1ID = id1;
        GameConfig.Player2ID = id2;
        p1 = new Player(10, id2, "Michal");
        players.Add(p0);
        players.Add(p1);
        var canvas = GameObject.FindGameObjectsWithTag("CharacterHolder");
        Debug.Log(canvas);
        if (players.Any())
        {
            for (int i=0;i< characters.Count; i++)
            {
                Debug.Log(characters.Count);
                GameObject characterObject = Instantiate(characterPrefab, transform);
                characterObject.GetComponent<CharacterDisplay>().player = players[i];
                //cardObject.GetComponent<CardDisplay>().card = cardList[randomCardIndex];
                //cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardList[randomCardIndex].cardType;
                //cardList.Remove(cardList[randomCardIndex]);
                characterObject.transform.SetParent(canvas[i].transform, false);
                Debug.Log(characters.Count);
            }

        }
        //p0.health = -1;
        //foreach (var character in characters)
        //{
        //    players.Add(character.player);
        //}
        //CardDisplay.instance.
    }
}
