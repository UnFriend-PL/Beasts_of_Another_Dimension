using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public List<GameObject> handFields, meleFields, rangeFields, effectFields = new List<GameObject>();

    void Start()
    {
        var zoneList = FindObjectsOfType<DropZone>();

        foreach(var obj in zoneList.Where(x => x.GetComponent<DropZone>().zoneOwnerId == -1))
        {
            obj.GetComponent<DropZone>().zoneOwnerId = GameConfig.Player1ID;
        } 
        foreach(var obj in zoneList.Where(x => x.GetComponent<DropZone>().zoneOwnerId == -2))
        {
            obj.GetComponent<DropZone>().zoneOwnerId = GameConfig.Player2ID;
        }
        var players = CharacterManager.instance.players;
        var handFields = GameObject.FindGameObjectsWithTag("Hand");
        var meleFields = GameObject.FindGameObjectsWithTag("Mele");
        var rangeFields = GameObject.FindGameObjectsWithTag("Range");
        var effectFields = GameObject.FindGameObjectsWithTag("Effect");
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
