using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GameObject itemSlotPrefab;


    public void UpdateIventory(Inventory inventory)
    {
        int slotsNum = scrollRect.content.childCount;
        Debug.Log($"slotsNum : {slotsNum}");
        for(int i = 0; i < slotsNum; i++)
        {
            Destroy(scrollRect.content.GetChild(0).gameObject);
        }

        foreach (var item in inventory.Items)
        {
            var slotObj = Instantiate(itemSlotPrefab, scrollRect.content);
            var slot = slotObj.GetComponent<UIInventorySlot>();
            slot.ShowItem(item.Key.Icon, item.Value);
        }
    }
}
