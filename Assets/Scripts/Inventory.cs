using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Inventory
{
    // 소지한 아이템과 개수를 저장
    Dictionary<ItemData, int> inven;
    public Dictionary<ItemData, int> Items
    {
        get { return inven; }
    }

    public Inventory()
    {
        inven = new Dictionary<ItemData, int>();
    }

    public bool InsertItem(ItemData item)
    {
        if (item.IsOwnable == false) return false;

        if (inven.ContainsKey(item))
        {
            if (inven[item] < item.OwnableNumber)
            {
                inven[item] += 1;
                UIManager.Instance.InvenUI.UpdateInventory(this);
                return true;
            }
            else
                return false;
        }
        else
        {
            inven.Add(item, 1);
            UIManager.Instance.InvenUI.UpdateInventory(this);
            return true;
        }
    }

    public void RemoveItem(ItemData item)
    {
        if (inven.ContainsKey(item))
        {
            inven[item]--;

            if (inven[item] <= 0)
            {
                inven.Remove(item);
            }
        }

        UIManager.Instance.InvenUI.UpdateInventory(this);
    }
}
