using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetEvent : MonoBehaviour
{

    private EventTrigger eventTrigger;
    private EventsManager eventsManager;

    private Image borderImage;
    private GameObject displayOptions;
    public Item item;

    public int id;

    private void Awake()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();
        eventsManager = FindAnyObjectByType<EventsManager>();
        borderImage = gameObject.transform.Find("Border").GetComponent<Image>();
        displayOptions = gameObject.transform.Find("DisplayOptions").gameObject;
        displayOptions.SetActive(false);

        EventTrigger.Entry pointerClickEntry = new EventTrigger.Entry();
        pointerClickEntry.eventID = EventTriggerType.PointerClick;
        pointerClickEntry.callback.AddListener((data) => { OnItemClicked((PointerEventData)data); }); 
        eventTrigger.triggers.Add(pointerClickEntry);

    }

    public void OnItemClicked(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            eventsManager.SetCurrentSelection(gameObject, item);
        }

        if (data.button == PointerEventData.InputButton.Right)
        {
            eventsManager.SetCurrentDisplayOptions(gameObject,displayOptions,item,id);
        }
    }


    public void Select()
    {
        borderImage.enabled = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
        if (displayOptions.activeInHierarchy) { displayOptions.SetActive(false); }
    }


}
