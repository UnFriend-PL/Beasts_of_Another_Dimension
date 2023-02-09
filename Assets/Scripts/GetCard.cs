using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GetCard : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;
    public Transform canvas;

    // Start is called before the first frame update
    void Start()
    {
        string[] assets = AssetDatabase.FindAssets("t:Card", new string[] { "Assets/Sprites/Cards/DemonsDeck" });
        canvas = transform;
        foreach (string asset in assets)
        {
            string path = AssetDatabase.GUIDToAssetPath(asset);
            Card card = AssetDatabase.LoadAssetAtPath<Card>(path);
            for(int i = 0; i <= card.countOfThisCardInDeck; i++) {
                cardList.Add(card);
            }
        }

        //foreach (Card card in cardList)
        //{
        //    GameObject cardObject = Instantiate(cardPrefab,  transform);
        //    cardObject.GetComponent<CardDisplay>().card = card;
        //    cardObject.GetComponent<Draggable>().cardZone = (Draggable.CardZones)card.cardType;
        //    cardObject.transform.SetParent(canvas.transform, false);
        //}
    }


    public void PutCardIntoHand()
    {
        System.Random rand = new System.Random();
        int randomCardIndex = rand.Next(0, cardList.Count);

        GameObject hand = GameObject.Find("Hand");
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
