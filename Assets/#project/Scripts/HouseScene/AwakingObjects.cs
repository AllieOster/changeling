using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakingObjects : MonoBehaviour
{
    public GameData gameData;
    // Start is called before the first frame update
    void Awake()
    {
        ManageCollectibleItems(gameData);
    }
    private static void ManageCollectibleItems(GameData gameData)
    {
        foreach (var item in GameObject.FindObjectsOfType<QuestItem>())
        {
            Debug.Log($"Checking item {item.name}");
            if (gameData.collectedItemIDs.Contains(item.itemId))
            {
                item.gameObject.SetActive(false); 
            }
        }
    }
}
