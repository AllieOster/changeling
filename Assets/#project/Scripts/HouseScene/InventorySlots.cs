using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlots : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int thisSlotIndex; 
    public int targetSlotIndex = -1; 
    public InventoryManager inventoryManager;
    public DragAndDropManager dgManager;
    public QuestItem questItem;

    private Vector3 initialPosition; 

    public void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        initialPosition = rt.position; 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    { 
        RectTransform rt = GetComponent<RectTransform>();

        Vector3 worldPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform)transform.parent, eventData.position, eventData.pressEventCamera, out worldPosition))
        {
            rt.position = worldPosition; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        RectTransform rt = GetComponent<RectTransform>();

        if (targetSlotIndex >= 0)
        {
            inventoryManager.Swap(thisSlotIndex, targetSlotIndex);
        }
        else
        {
            rt.position = initialPosition; 
            Debug.Log("Returned to initial position");
        }
        targetSlotIndex = -1;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter on Slot: " + thisSlotIndex);
        targetSlotIndex = thisSlotIndex; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit on Slot: " + thisSlotIndex);
        targetSlotIndex = -1;
        thisSlotIndex = -1; // réinitialise correctement mais fout le bowdel ensuite
    }
}