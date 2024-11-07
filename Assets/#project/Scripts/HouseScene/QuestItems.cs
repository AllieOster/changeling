using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public InventoryManager inventoryManager; 

    void OnMouseDown()
    {
        Debug.Log("clicked on something");
        inventoryManager.AddToInventory(this.gameObject);
    }
}