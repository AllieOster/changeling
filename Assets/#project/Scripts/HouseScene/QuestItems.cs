using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public GameData gameData; 
    public InventoryManager inventoryManager; 

    public ItemID itemId;    

    void OnMouseDown()
    {
        Debug.Log($"clicked on something with tag {this.gameObject.tag}");
        if (!gameData.collectedItems.Contains(this.gameObject)) 
        {
            if (LevelManager.CurrentState == GameState.Lvl1)
            {
                    inventoryManager.AddToInventory(this.gameObject);
                    Debug.Log($"{this.gameObject} added to the liiiiiist as expected");
                    gameData.collectedItems.Add(this.gameObject); 
                    gameData.collectedItemIDs.Add(itemId);
                    gameObject.SetActive(false); 
            }
            if (LevelManager.CurrentState == GameState.Lvl2)
            {
                if (this.gameObject.CompareTag("QuestItemsLvl2"))
                {
                    inventoryManager.AddToInventory(this.gameObject);
                    Debug.Log($"{this.gameObject} added to the liiiiiist as expected");
                    gameData.collectedItems.Add(this.gameObject); 
                    gameData.collectedItemIDs.Add(itemId);
                    gameObject.SetActive(false); 
                }
            }
            if (LevelManager.CurrentState == GameState.Lvl3)
            {
                if (this.gameObject.CompareTag("QuestItemsLvl3"))
                {
                    inventoryManager.AddToInventory(this.gameObject);
                    Debug.Log($"{this.gameObject} added to the liiiiiist as expected");
                    gameData.collectedItems.Add(this.gameObject); 
                    gameData.collectedItemIDs.Add(itemId);
                    gameObject.SetActive(false); 
                }
            }            
        }
        else
        {
            Debug.Log("Item already collected."); 
        }
    }
}