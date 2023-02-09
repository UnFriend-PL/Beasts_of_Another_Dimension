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
    public List<Card> cards = new List<Card>();
    public Transform player1Hand, player2Hand;

    public List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        string[] assets = AssetDatabase.FindAssets("t:Card", new string[] { "Assets/Sprites/Cards/DemonsDeck" });
        //player1Hand = transform;
        foreach (string asset in assets)
        {
            string path = AssetDatabase.GUIDToAssetPath(asset);
            Card card = AssetDatabase.LoadAssetAtPath<Card>(path);
            for (int i = 0; i <= card.countOfThisCardInDeck; i++)
            {
                cardList.Add(card);
            }
        }

        GenerateStartCards();
    }

    private void GenerateStartCards()
    {
        for (int i = 0; i < 5; i++)
        {
            System.Random rand = new System.Random();
            int randomCardIndex = rand.Next(0, cardList.Count);
            //GameObject hand = GameObject.Find("Hand");
            var hand = player1Hand;
            var hand2 = player2Hand;
            if (cardList.Any())
            {
                Debug.Log(cardList.Count);
                GameObject cardObject = Instantiate(cardPrefab, transform);
                GameObject cardObject2 = Instantiate(cardPrefab, transform);
                cardObject.GetComponent<CardDisplay>().card = cardList[randomCardIndex];
                cardObject2.GetComponent<CardDisplay>().card = cardList[randomCardIndex];
                cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardList[randomCardIndex].cardType;
                cardObject.GetComponent<CardDisplay>().card.ownerID = player1Hand.GetComponent<DropZone>().zoneOwnerId;
                cardObject2.GetComponent<CardDisplay>().card.ownerID = player2Hand.GetComponent<DropZone>().zoneOwnerId;
                cardObject2.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardList[randomCardIndex].cardType;
                cardList.Remove(cardList[randomCardIndex]);
                cardObject.transform.SetParent(hand.transform, false);
                cardObject2.transform.SetParent(hand2.transform, false);
                Debug.Log(cardList.Count);

            }
        }
    }


    public void PutCardIntoHand()
    {
        System.Random rand = new System.Random();
        int randomCardIndex = rand.Next(0, cardList.Count);
        var hand = player1Hand;
        //GameObject hand = GameObject.Find("Hand");
        if (cardList.Any())
        {
            Debug.Log(cardList.Count);
            GameObject cardObject = Instantiate(cardPrefab, transform);
            cardObject.GetComponent<CardDisplay>().card = cardList[randomCardIndex];
            cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)cardList[randomCardIndex].cardType;
            cardList.Remove(cardList[randomCardIndex]);
            cardObject.transform.SetParent(hand.transform, false);
            Debug.Log(cardList.Count);

        }
    }
}
