using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Inventory
{
    // ������ �����۰� ������ ����
    Dictionary<ItemData, int> inven;


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
                return true;
            }
            else
                return false;
        }
        else
        {
            inven.Add(item, 1);
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
    }
}