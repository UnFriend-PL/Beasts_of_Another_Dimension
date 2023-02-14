using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{
    public static int Player1ID { get; set; }
    public static int Player2ID { get; set; }
    public static List<Card> Player1Deck { get; set; }
    public static List<Card> Player2Deck { get; set; }
    private static string cardAssetsPath = "Assets/Sprites/Cards/";
    private static string demonsDeckFolderName = "DemonsDeck";
    public static string CardAssetsPath { get { return cardAssetsPath; } }
    public static string DemonsDeckFolderName { get { return demonsDeckFolderName; } }

}
