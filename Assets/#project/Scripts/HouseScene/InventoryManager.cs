using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    /*
    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                    The Inventory Manager

        ❤ Add things into the inventory (change sprite for the item sprite)
        ❤ Clear Inventory when full
        ❤ Change GameState when full

    ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    */
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
                slots[currentSlot].tag = item.tag;
                slotSprite.sprite = itemSprite.sprite; 
                item.SetActive(false);
                currentSlot++;
                checkIfInventoryFull();
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

    public void checkIfInventoryFull()
    {
        if (currentSlot == 5 && LevelManager.CurrentState == GameState.Lvl1) 
        {
            LevelManager.SetGameState(GameState.TransitionLvl2); 
            Debug.Log($"State changed for : {LevelManager.CurrentState}");
            currentSlot = 0;
            Invoke("ClearInventory", 2f);
            LoadSceneManager.ChangeScene("TransitionOne");
            Debug.Log($"current slot = {currentSlot}");
            return; 
        }
    }
}