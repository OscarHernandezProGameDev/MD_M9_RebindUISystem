using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {  get; private set; }

    private void Awake()
    {
        Instance = this; 
    }


    public Transform itemWorldPrefab;

    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite swordSprite;
    public Sprite coinSprite;
    public Sprite stoneSprite;
    public Sprite ringSprite;

}
