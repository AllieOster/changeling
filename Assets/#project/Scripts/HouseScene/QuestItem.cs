using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{
    public InventoryManager inventoryManager;   
    public string itemID;
    void OnMouseDown()
    {
        Debug.Log($"clicked on something with tag {this.gameObject.tag}");
        if (LevelManager.CurrentState == GameState.Lvl1)
        {
            if(this.gameObject.CompareTag("QuestItemsLvl1"))
            {
                inventoryManager.AddToInventory(this.gameObject);
                gameObject.SetActive(false); 
            }  
        }
        if (LevelManager.CurrentState == GameState.Lvl2)
        {
            if (this.gameObject.CompareTag("QuestItemsLvl2"))
            {
                inventoryManager.AddToInventory(this.gameObject);
                gameObject.SetActive(false); 
            }
        }
        if (LevelManager.CurrentState == GameState.Lvl3)
        {
            if (this.gameObject.CompareTag("QuestItemsLvl3"))
            {
                inventoryManager.AddToInventory(this.gameObject);
                gameObject.SetActive(false); 
            }
        }            
    }
}