using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public Sprite iconCardType;
    public int hp;
    public int manaCost;
    public int dmg;
    public string cardDescription;
    public cardTypes cardType;
    public int countOfThisCardInDeck = 1;
    public int ownerID =-1;

    public enum cardTypes {
        Hand,
        Range,
        Mele,
        Effect
    }
}
