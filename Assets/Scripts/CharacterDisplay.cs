using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public static CharacterDisplay instance;
    public Character character;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterLvl;
    public TextMeshProUGUI currentMana;
    public TextMeshProUGUI maxMana;
    public TextMeshProUGUI nickname;
    public TextMeshProUGUI currentHp;
    public Image avatar;
    public Player player;

    void Start()
    {
        characterName.text = character.nickName;
        characterLvl.text = $"{character.lvl} LvL";
        currentMana.text = character.currentMana.ToString();
        maxMana.text = character.maxMana.ToString();
        currentHp.text = player.health.ToString();
        avatar.sprite = character.avatar;
        nickname.text = player.name;
    }

    private void Awake()
    {
        instance = this;
    }
}
