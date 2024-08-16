using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private GameObject itemsTemplate;

    private Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemsContainer)
        {
            if (child == itemsTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.GetItemList())
        {
            var newUiItem = Instantiate(itemsTemplate, itemsContainer).GetComponent<RectTransform>();
            newUiItem.name = item.itemType.ToString();

            var image = newUiItem.Find("Border/Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = newUiItem.Find("Border/Image/TextBackground/Text").GetComponent<TextMeshProUGUI>();

            if(item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.transform.parent.gameObject.SetActive(false);
            }

            var eventScript = newUiItem.AddComponent<SetEvent>();
            eventScript.item = item;
            eventScript.id = item.id;

        }
    }

}
