using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectDeck : MonoBehaviour
{
    public TextMeshProUGUI title;
    public void SelectCurrentDeck()
    {
        MainMenu.instance.SetSelectedDeck(title.text);
    }
}
