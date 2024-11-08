using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] slots; 
    public int currentSlot = 0;

    public void AddToInventory(GameObject item)
    {
        Debug.Log("AddToInventory Activated");
        SpriteRenderer itemSprite = item.GetComponent<SpriteRenderer>();
        
        if (itemSprite == null)
        {
            Debug.LogWarning("Pas de sprite renderer");
            return; 
        }

        SpriteRenderer slotSprite = slots[currentSlot].GetComponent<SpriteRenderer>();

        if(slotSprite.sprite == null)
        {
            slotSprite.sprite = itemSprite.sprite; 
            item.SetActive(false);
            currentSlot++;
            Debug.Log($"current slot = {currentSlot}");
            return; 
        }
    }
}