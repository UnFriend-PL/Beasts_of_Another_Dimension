using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterLvl;
    public TextMeshProUGUI currentMana;
    public TextMeshProUGUI maxMana;
    public Image avatar;

    void Start()
    {
        characterName.text = character.nickName;
        characterLvl.text = $"{character.lvl} LvL";
        currentMana.text = character.currentMana.ToString();
        maxMana.text = character.maxMana.ToString();
        avatar.sprite = character.avatar;
    }

}
