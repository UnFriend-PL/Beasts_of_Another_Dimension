using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TextMeshProUGUI currentPlayerTurn;
    public Button endTurnButton;

    public void Awake()
    {
        instance = this;
        SetUpButtons();
    }

    private void SetUpButtons()
    {
        endTurnButton.onClick.AddListener(() =>
        {
            TurnManager.instance.EndTurn();
        });
    }

    public void UpdateCurrentPlayerTurn(int playerID, string name)
    {
        currentPlayerTurn.gameObject.SetActive(true);
        currentPlayerTurn.text = $"{name}'s Turn";
        StartCoroutine(BlinkCurrnetPlayerTurn());
    }

    private IEnumerator BlinkCurrnetPlayerTurn()
    {
        yield return new WaitForSeconds(1);
        currentPlayerTurn.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        currentPlayerTurn.gameObject.SetActive(true); 
        yield return new WaitForSeconds(1);
        currentPlayerTurn.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        currentPlayerTurn.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        currentPlayerTurn.gameObject.SetActive(false);
    }
}
