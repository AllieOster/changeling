using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class QuestItem : MonoBehaviour
{
    public InventoryManager inventoryManager; 
    void OnMouseDown()
    {
        Debug.Log($"clicked on something with tag {this.gameObject.tag}");
        if (LevelManager.CurrentState == GameState.Lvl1)
        {
            if (this.gameObject.CompareTag("QuestItemsLvl1"))
            {
                inventoryManager.AddToInventory(this.gameObject); 
            }
        }    
        if (LevelManager.CurrentState == GameState.Lvl2)
        {
            if (this.gameObject.CompareTag("QuestItemsLvl2"))
            {
                inventoryManager.AddToInventory(this.gameObject); 
            }
        }  
        if (LevelManager.CurrentState == GameState.Lvl3)
        {
            if (this.gameObject.CompareTag("QuestItemsLvl3"))
            {
                inventoryManager.AddToInventory(this.gameObject); 
            }
        }  
    }
}

// 👽👽👽👽👽 -- Ici on va mettre un switch ou une conditonnelle pour que les questItems
// correspondent : if questItem number = lvlnumber alors on peut addToInventory
// Sinon c'est le texte qui va avec (???) 👽👽👽👽👽
// VOIR SI ON PEUT CHOISIR UN COMPORTEMENT OU L AUTRE POUR LE COLLIDER ????