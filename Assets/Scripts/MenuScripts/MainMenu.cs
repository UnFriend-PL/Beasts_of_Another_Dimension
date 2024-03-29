using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public TMP_InputField inputField;
    private string selectedDeck;
    public static MainMenu instance;
    private void Start()
    {
        instance = this;
        //GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;
        //inputField = GameObject.FindObjectOfType<TMP_InputField>();
    }
    public void PlayGame()
    {
        if (CheckDefaultValuesToStartGame()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public bool CheckDefaultValuesToStartGame()
    {
        //var playerNickname = GameObject.Find()
        bool isCorrect = true;
        if(inputField == null || inputField.text == "") { 
            isCorrect = false;
        }
        var selectedDeckName = GameObject.Find("SelectedDeckName").GetComponent<TextMeshProUGUI>().text;
        if(selectedDeckName == "" || selectedDeckName == null || selectedDeckName == "Selected Deck")
        {
            isCorrect= false;
        }

        return isCorrect;
    }

    public void SetSelectedDeck(string deckName)
    {
        Debug.Log(deckName);
        selectedDeck= deckName;
        GameObject.Find("SelectedDeckName").GetComponent<TextMeshProUGUI>().text = selectedDeck;
    }

}
