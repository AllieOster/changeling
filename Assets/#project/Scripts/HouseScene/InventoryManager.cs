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
        
        item.SetActive(false);

        if(InventoryIsFull && LevelManager.CurrentState == GameState.Lvl1)
        {
            whenInventoryIsFull?.Invoke();
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

        if (LevelManager.CurrentState == GameState.Lvl1)
        {
            LevelManager.SetGameState(GameState.TransitionLvl2);
            Debug.Log($"State changed for : {LevelManager.CurrentState}");
            yield return new WaitForSeconds(1f);
            LoadSceneManager.ChangeScene("TransitionOne");
        }
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

    // public void Swap()
    // {
        // Ici on va swiper avec 
        /* 
        --> SpriteRenderer
        --> SlotIndex           // Replace "currentSlot" by slotIndex elsewhere ??? 
        --> ItemID               

        ---> Variable temporaire dans laquelle placer le sprite
        ---> mettre le sprite n°1 dans le temporaire 
        ---> mettre le sprite n°2 dans le n°1 
        ---> mettre le temporaire dans le n°2

        */
    // }
}