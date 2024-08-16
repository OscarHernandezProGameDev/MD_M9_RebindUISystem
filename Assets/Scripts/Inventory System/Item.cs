using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType
    {
         HealthPotion,
         ManaPotion,
         Sword,
         Coin,
         Stone,
         Ring
    }

    public int id;
    public ItemType itemType;
    public int amount;

    private readonly string healthPotionDescription = "It heals 20 hp points. It's addictive, take them easy.";
    private readonly string manaPotionDescription = "It restore 20 mana points.";
    private readonly string swordDescription = "A normal sword, it cuts things.";
    private readonly string coinDescription = "A coin is a coin, its valious.";
    private readonly string stoneDescription = "A piece of stone material, you can use it to build things.";
    private readonly string ringDescription = "This ring is a gift, keep it safe.";



    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite; 
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
            case ItemType.Stone:        return ItemAssets.Instance.stoneSprite;
            case ItemType.Ring:         return ItemAssets.Instance.ringSprite;

        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
            case ItemType.Coin:
            case ItemType.Stone: 
                return true;
            case ItemType.Sword:
            case ItemType.Ring:
                return false;
        }
    }


    public bool IsUsable()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                    return true;
            case ItemType.Sword:
            case ItemType.Ring: 
            case ItemType.Stone:
            case ItemType.Coin:
                  return false;
        }
    }


    public string GetDescription()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return healthPotionDescription;
            case ItemType.ManaPotion:   return manaPotionDescription;
            case ItemType.Coin:         return coinDescription;
            case ItemType.Stone:        return stoneDescription;
            case ItemType.Sword:        return swordDescription;
            case ItemType.Ring:         return ringDescription; 
        }
    }


}
