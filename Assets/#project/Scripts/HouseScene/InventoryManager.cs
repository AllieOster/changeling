using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
    /*
    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻🦋༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                    The Inventory Manager

        ❤ Add things into the inventory (change sprite for the item sprite)
        ❤ Clear Inventory when full
        ❤ Change GameState when full
        --> https://pbs.twimg.com/profile_images/1080982447939043329/-LKZ_WpQ_200x200.jpg

    ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━༻⭐️༺━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    */
    [SerializeField] GameObject[] slots;
    [SerializeField] UnityEvent whenInventoryIsFull;
    Dictionary<GameObject, string> itemsDict = new();

    public void AddToInventory(GameObject item, int index = -1)
    {
        if(index == -1)
        {
            index = FindEmptyIndex();
            if(index == -1){
                Debug.Log("Inventaire rempli.");
                return;
            }
        }

        SpriteRenderer itemSprite = item.GetComponent<SpriteRenderer>();

        if (itemSprite == null)
        {
            Debug.LogWarning("Pas de sprite renderer");
            return; 
        }

        SpriteRenderer slotSprite = slots[index].GetComponent<SpriteRenderer>();

        QuestItem itemid = item.GetComponent<QuestItem>();

        slotSprite.sprite = itemSprite.sprite;

        if(itemid.itemID != null)
        {
            itemsDict.Add(slots[index], itemid.itemID);
            Debug.Log("added to Dict Inventory");
        }
        else
        {
            Debug.LogWarning("Pas de questItem!!!");
        }
        Debug.Log($"{itemid.itemID} added");
        
        item.SetActive(false);

        if(InventoryIsFull)
        {
            StartClearingInventory();
        }
    }
    public IEnumerator ClearInventory()
    {
        yield return new WaitForSeconds(2f); 
        foreach (GameObject slot in slots)
        {
            SpriteRenderer slotSprite = slot.GetComponent<SpriteRenderer>();
            if (slotSprite != null && slotSprite.sprite != null)
            {
                slotSprite.sprite = null;
            }
        }
        itemsDict.Clear();
        Debug.Log("Inventory cleared.");
        yield return new WaitForSeconds(2f);
        whenInventoryIsFull?.Invoke();
    }

    public void StartClearingInventory()
    {
        StartCoroutine(ClearInventory());
    }
    private int FindEmptyIndex()
    {
        int index = -1;

        for(int i = 0; i < slots.Length; i++)
        { 
            SpriteRenderer slotSprite = slots[i].GetComponent<SpriteRenderer>();
            if (slotSprite != null && slotSprite.sprite == null){ 
                index = i;
                break;
            }
        }
        return index;
    }
    public bool InventoryIsFull 
    {
        get{return FindEmptyIndex() == -1;}
    }

    public void Swap(int index1, int index2)
    {
        Debug.Log("Tried to swap");
        if (index1 < 0 || index1 >= slots.Length || index2 < 0 || index2 >= slots.Length)
        {
            Debug.LogWarning("Index invalide.");
            return;
        }

        SpriteRenderer slotSprite1 = slots[index1].GetComponent<SpriteRenderer>();
        SpriteRenderer slotSprite2 = slots[index2].GetComponent<SpriteRenderer>();

        if (slotSprite1 == null || slotSprite2 == null)
        {
            Debug.LogWarning("L'un des slots n'a pas de SpriteRenderer.");
            return;
        }

        Sprite tempSprite = slotSprite1.sprite;
        slotSprite1.sprite = slotSprite2.sprite;
        slotSprite2.sprite = tempSprite;

        if (itemsDict.ContainsKey(slots[index1]) && itemsDict.ContainsKey(slots[index2]))
        {
            string tempItemID = itemsDict[slots[index1]];
            itemsDict[slots[index1]] = itemsDict[slots[index2]];
            itemsDict[slots[index2]] = tempItemID;
        }
        else
        {
            Debug.LogWarning("L'un des slots n'a pas d'item associé dans le dictionnaire.");
        }
    }
}