using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] slots; 
    public int currentSlot = 0;

    public void AddToInventory(GameObject item)
    {
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
                if (currentSlot == 5) 
                {
                    LevelManager.SetGameState(GameState.Lvl2); // 🦩🦩🦩 --> A changer pour intro le jour venu 
                    Debug.Log("Lvl2 activated");
                    currentSlot = 0;
                    Invoke("ClearInventory", 2f);
                }
                Debug.Log($"current slot = {currentSlot}");
                return; 
            }
    }
    public void ClearInventory()
    {
        foreach (GameObject slot in slots)
        {
            SpriteRenderer slotSprite = slot.GetComponent<SpriteRenderer>(); 

            if (slotSprite != null && slotSprite.sprite != null)
            {
                slotSprite.sprite = null; 
            }
        }

        Debug.Log("Inventory cleared.");
    }
}