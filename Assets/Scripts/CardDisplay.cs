using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Card card;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescription;
    public Image cardImage;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI dmg;
    public Image cardType;

    void Start()
    {
        cardNameText.text = card.cardName;
        cardDescription.text = card.cardDescription;
        cardImage.sprite = card.cardImage;
        manaText.text = card.manaCost.ToString();
        hp.text = card.hp.ToString();
        dmg.text = card.dmg.ToString();
        cardType.sprite = card.iconCardType;
    }
}
