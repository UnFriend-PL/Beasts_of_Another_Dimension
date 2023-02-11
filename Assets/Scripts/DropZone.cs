using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.CardZones CardsZone = Draggable.CardZones.Mele;
    public bool canBeDragged = true;
    public int zoneOwnerId = -1;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            var cardOwnerId = d.gameObject.GetComponent<CardDisplay>().ownerId;
            CharacterDisplay character = GameObject.FindObjectsOfType<CharacterDisplay>().Where(x => x.player.ID == cardOwnerId).First();
            Debug.Log(character.name);
            var player = character.player;
            if (CardsZone == d.cardZone && zoneOwnerId == cardOwnerId && player.myTurn)
            {
                if (Convert.ToInt32(character.currentMana.text) < Convert.ToInt32(eventData.pointerDrag.GetComponent<CardDisplay>().manaText.text))
                {
                    Debug.Log($"{eventData.pointerDrag.name} can not be dragged because mana is too small");
                    return;
                }

                character.currentMana.text = $"{Convert.ToInt32(character.currentMana.text) - Convert.ToInt32(eventData.pointerDrag.GetComponent<CardDisplay>().manaText.text)}";

                Debug.Log($"{eventData.pointerDrag.name} was dropped on {gameObject.name}");
                d.parentToReturnTo = transform;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (CardsZone == d.cardZone)
                d.placeholderParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform)
        {
            if (CardsZone == d.cardZone)
                d.placeholderParent = d.parentToReturnTo;
        }

    }
}
