using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;


    GameObject placeHolder = null;

    public CardZones cardZone = CardZones.Range;

    public enum CardZones
    {
        Hand,
        Range,
        Mele,
        Effect
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        //Debug.Log("OnBeeingDrag");
        parentToReturnTo = transform.parent;
        placeholderParent = parentToReturnTo;

        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        //Debug.Log("OnBeeingDrag");
        transform.position = eventData.position;

        if (placeHolder.transform.parent != placeholderParent)
        {
            placeHolder.transform.SetParent(placeholderParent);
        }


        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //Debug.Log("OnEndDrag");
        transform.SetParent(parentToReturnTo);
        transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeHolder);
    }
}
