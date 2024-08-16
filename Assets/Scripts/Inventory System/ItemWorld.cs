using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.itemWorldPrefab, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector2 randomDir;
        int chooseDir = Random.Range(0, 2);

        if(chooseDir == 0) { randomDir = Vector2.left; } else {  randomDir = Vector2.right; }

        ItemWorld itemWorld = SpawnItemWorld((Vector2)dropPosition + randomDir * 1f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 1f,ForceMode2D.Impulse);

        return itemWorld;
    }


    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

        if(item.IsStackable() )
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.text = "";
        }
    }


    public Item GetItem()
    {
        return item;
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
