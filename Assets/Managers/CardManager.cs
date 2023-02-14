using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    //public List<Card> cards = new List<Card>();
    public Transform player1Hand, player2Hand;

    public List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetDeck(GameConfig.Player1ID, GameConfig.DemonsDeckFolderName);
        SetDeck(GameConfig.Player2ID, GameConfig.DemonsDeckFolderName);

        GenerateStartCards(GameConfig.Player1ID);
        GenerateStartCards(GameConfig.Player2ID);
    }

    public void SetDeck(int playerId, string deckName)
    {
        string[] cardDeck = AssetDatabase.FindAssets("t:Card", new string[] { $"{GameConfig.CardAssetsPath}{deckName}" });
        //player1Hand = transform;
        int counter = 0;
        List<Card> p1Deck = new List<Card>();
        List<Card> p2Deck = new List<Card>();
        foreach (string asset in cardDeck)
        {
            string path = AssetDatabase.GUIDToAssetPath(asset);
            Card card = AssetDatabase.LoadAssetAtPath<Card>(path);
            for (int i = 0; i <= card.countOfThisCardInDeck; i++)
            {
                card.cardID = counter;
                counter++;
                if (GameConfig.Player1ID == playerId)
                {
                    p1Deck.Add(card);
                }
                else
                {
                    p2Deck.Add(card);

                }
            }
        }
        if (GameConfig.Player1ID == playerId)
        {
            GameConfig.Player1Deck = p1Deck;
        }
        else
        {
            GameConfig.Player2Deck = p2Deck;
        }
    }


    private void GenerateStartCards(int playerId)
    {
        List<Card> cardDeck;
        DropZone hand;
        if (GameConfig.Player1ID == playerId)
        {
            cardDeck = GameConfig.Player1Deck;
            hand = player1Hand.GetComponent<DropZone>();
        }
        else if (GameConfig.Player2ID == playerId)
        {
            cardDeck = GameConfig.Player2Deck;
            hand = player2Hand.GetComponent<DropZone>();
        }
        else
        {
            throw new Exception("No found pllayer");
        }
        for (int i = 0; i < 5; i++)
        {
            System.Random rand = new System.Random();
            int randomCardIndex = rand.Next(0, cardDeck.Count);
            if (cardDeck.Any())
            {
                GameObject cardObject = Instantiate(cardPrefab, transform);
                cardObject.GetComponent<CardDisplay>().card = cardDeck[randomCardIndex];
                cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardDeck[randomCardIndex].cardType;
                cardObject.GetComponent<CardDisplay>().ownerId = playerId;
                cardDeck.Remove(cardDeck[randomCardIndex]);
                cardObject.transform.SetParent(hand.transform, false);
            }
        }
    }


    public void PutCardIntoHand(int playerId)
    {
        List<Card> cardDeck;
        DropZone hand;
        if (GameConfig.Player1ID == playerId)
        {
            cardDeck = GameConfig.Player1Deck;
            hand = player1Hand.GetComponent<DropZone>();
        }
        else if (GameConfig.Player2ID == playerId)
        {
            cardDeck = GameConfig.Player2Deck;
            hand = player2Hand.GetComponent<DropZone>();
        }
        else
        {
            throw new Exception("No found pllayer");
        }
        System.Random rand = new System.Random();
        int randomCardIndex = rand.Next(0, cardDeck.Count);
        if (cardDeck.Any())
        {
            Debug.Log(cardDeck.Count);
            GameObject cardObject = Instantiate(cardPrefab, transform);
            cardObject.GetComponent<CardDisplay>().card = cardDeck[randomCardIndex];
            cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardDeck[randomCardIndex].cardType;
            cardDeck.Remove(cardDeck[randomCardIndex]);
            cardObject.transform.SetParent(hand.transform, false);
            Debug.Log(cardDeck.Count);

        }
    }
}
