using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private EventsManager eventsManager;

    private Inventory inventory;
    public bool AtInventory { get; private set; }

    private Slider healthBar, manaBar;
    private int health = 50,mana = 50;

    [SerializeField] private VerticalLayoutGroup barsLayout;
    private RectOffset rectOffset;


    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        CloseIventory();

        healthBar = GameObject.Find("Bar_Health").GetComponent<Slider>();
        manaBar = GameObject.Find("Bar_Mana").GetComponent<Slider>();

        healthBar.value = health;
        manaBar.value = mana;

    }

    private void Update()
    {
        Keyboard myKeyboard = Keyboard.current;
        if (myKeyboard != null)
        {
            if(myKeyboard.tabKey.wasPressedThisFrame)
            {
                if(inventoryMenu.activeInHierarchy)
                {
                    CloseIventory();
                }
                else
                {
                    OpenInventory();
                }
            }
        }
    }

    private void OpenInventory()
    {
        rectOffset = new RectOffset() { left = 20, right = 20, top = 960, bottom = 40 };
        barsLayout.padding = rectOffset;
        barsLayout.childAlignment = TextAnchor.LowerLeft;

        inventoryMenu.SetActive(true);
        AtInventory = true;
    }

    public void CloseIventory()
    {
        rectOffset = new RectOffset() { left = 20, right = 20, top = 10, bottom = 980 };
        barsLayout.padding = rectOffset;
        barsLayout.childAlignment = TextAnchor.UpperLeft;

        inventoryMenu.SetActive(false);
        eventsManager.CleanSelection();
        AtInventory = false;    
    }


    public void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.HealthPotion:

                int newHealth = health + 10;
                StartCoroutine(UpdateHealthBar(newHealth));
                break;

            case Item.ItemType.ManaPotion:

                int newMana = mana + 10;
                StartCoroutine(UpdateManaBar(newMana));
                break;
        }

        inventory.UseItem(item);

    }


    private IEnumerator UpdateHealthBar(int newHealth)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;
        int initialHealth = health;

        health = Mathf.Clamp(newHealth, 0, 100);

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            healthBar.value = Mathf.Lerp(initialHealth, health, elapsedTime/duration);
            yield return null;
        }

        healthBar.value = health;
    }

    private IEnumerator UpdateManaBar(int newMana)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;
        int initialMana = mana;

        mana = Mathf.Clamp(newMana, 0, 100);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            manaBar.value = Mathf.Lerp(initialMana, mana, elapsedTime / duration);
            yield return null;
        }

        manaBar.value = mana;
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

}
