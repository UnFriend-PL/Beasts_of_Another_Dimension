using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player 
{
    public int health;
    public int ID;
    public string nickName;
    public bool myTurn;
    public GameObject character;
    public Player(int health, int ID, string nickName, GameObject character)
    {
        this.health = health;
        this.ID = ID;
        this.nickName = nickName;
        this.character = character;
    }   
}
