using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player 
{
    public int health;
    public int ID;
    public string name;
    public bool myTurn;
    public Player(int health, int ID, string name)
    {
        this.health = health;
        this.ID = ID;
        this.name = name;
    }   
}
