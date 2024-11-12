using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public List<GameObject> collectedItems = new List<GameObject>(); 
    public List<ItemID> collectedItemIDs = new List<ItemID>();
    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameData>("GameData");
                if (instance == null)
                {
                    Debug.LogError("Trouve pas de gameData");
                }
            }
            return instance;
        }
    }
}