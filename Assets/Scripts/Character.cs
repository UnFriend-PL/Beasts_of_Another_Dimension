using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class Character : ScriptableObject
{
    public Sprite avatar;
    public string nickName;
    public int maxMana = 12;
    public int currentMana;
    public float lvl = 13f;

}
