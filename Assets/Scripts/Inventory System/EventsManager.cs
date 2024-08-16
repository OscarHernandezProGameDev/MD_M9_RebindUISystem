using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Image currentSelectionImage;
    [SerializeField] private TextMeshProUGUI currentSelectionTittle;
    [SerializeField] private TextMeshProUGUI currentSelectionDescription;

    private GameObject currentSelection;
    private SetEvent currentSetEvent;
    private GameObject selectedDisplayOptions;

    private Player player;
    private Inventory myInventory;

    private Color transparentColor = new Color(0,0,0,0);

    private Button useButton;
    private Button dropButton;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();

        currentSelection = null;
        currentSelectionImage.color = transparentColor;
        currentSelectionTittle.text = "";
        currentSelectionDescription.text = "";
    }

    public void SetCurrentSelection(GameObject selection, Item item)
    {
        if(selection != currentSelection)
        {
            if(currentSetEvent != null)
            {
                currentSetEvent.Deselect();
            }

            currentSetEvent = selection.GetComponent<SetEvent>();
            currentSetEvent.Select();
            currentSelection = selection;

            currentSelectionImage.sprite = item.GetSprite();
            currentSelectionImage.color = Color.white;
            currentSelectionTittle.text = AddSpacesToCamelCase(item.itemType.ToString());
            currentSelectionDescription.text = item.GetDescription();

            myInventory = player.GetInventory();
        }
        else
        {
            CleanSelection();
        }

    }

    public void SetCurrentDisplayOptions(GameObject selection, GameObject displayOptions, Item item, int id)
    {
        selectedDisplayOptions = displayOptions;

        if(currentSelection != selection) {  SetCurrentSelection(selection,item); }

        if (displayOptions.activeInHierarchy)
        {
            displayOptions.SetActive(false);
        }
        else
        {
            displayOptions.SetActive(true);

            dropButton = displayOptions.transform.Find("Panel/Button_Drop").GetComponent<Button>();
            dropButton.onClick.AddListener(delegate { DropItem(item,id); });

            useButton = displayOptions.transform.Find("Panel/Button_Use").GetComponent<Button>();
           

            if (!item.IsUsable())
            {
                useButton.interactable = false;
            }
            else
            {
                useButton.onClick.AddListener(delegate { UseItem(item, id); });
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
            CleanSelection();
    }



    public void UseItem(Item item, int id)
    {
        if (id == item.id)
        {
            player.UseItem(item);
            CleanSelection();
        }
    }

    public void DropItem(Item item,int id)
    {
        if(id == item.id)
        {
            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            myInventory.RemoveItem(item);
            CleanSelection();
            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        }
      
    }



    public void CleanSelection()
    {
        if (currentSelection != null)
        {
            currentSetEvent.Deselect();
            currentSetEvent = null;
            currentSelection = null;
            currentSelectionImage.color = transparentColor;
            currentSelectionTittle.text = "";
            currentSelectionDescription.text = "";
        }
        if(selectedDisplayOptions != null) { selectedDisplayOptions.SetActive(false); selectedDisplayOptions = null; }
    }


    private string AddSpacesToCamelCase(string text)
    {
        return Regex.Replace(text, "(\\B[A-Z])", " $1");
    }

}
