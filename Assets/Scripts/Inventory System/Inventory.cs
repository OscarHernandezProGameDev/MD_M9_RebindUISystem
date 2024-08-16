using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList;
    private static int nextId = 0;

    public Inventory()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.HealthPotion,amount = 99 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Sword,amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 98 });
    }


    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType)
                {
                    int totalAmount = inventoryItem.amount + item.amount;
                    if (totalAmount <= 99)
                    {
                        inventoryItem.amount += item.amount;
                        itemAlreadyInInventory = true;
                    }
                    else
                    {
                        int remainingAmount = totalAmount - 99;
                        inventoryItem.amount = 99;
                        item.amount = remainingAmount;
                    }
                }
            }

            if(!itemAlreadyInInventory)
            {
                itemList.Add(item);
                item.id = GenerateUniqueId();
            }
        }
        else
        {
            itemList.Add(item);
            item.id = GenerateUniqueId();
        }

        OnItemListChanged?.Invoke(this, new EventArgs());
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.id == item.id)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }

            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }


        OnItemListChanged?.Invoke(this, new EventArgs());
    }




    public void UseItem(Item item)
    {
        if (item.amount > 1)
        {
            item.amount--;
        }
        else
        {
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, new EventArgs());
    }

    private int GenerateUniqueId()
    {
        return nextId++;
    }


    public List<Item> GetItemList()
    {
        return itemList;
    }

}
