using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    public InventorySlots currentDraggedSlot; 
    public void StartDrag(InventorySlots slot)
    {
        currentDraggedSlot = slot;
    }

    public void EndDrag()
    {
        currentDraggedSlot = null;
    }
}