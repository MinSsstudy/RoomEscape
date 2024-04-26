using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",
    menuName = "ScriptableObjects/ItemData",
    order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField] string itemName;
    public string ItemName
    {
        get
        {
            return itemName;
        }
    }

    [SerializeField] string descrition;
    public string Descrition
    {
        get
        {
            return descrition;
        }
    }

    [SerializeField] bool isOwnable = false;
    public bool IsOwnable
    {
        get
        {
            return isOwnable;
        }
    }

    [SerializeField] int ownableNumber = 0;
    public int OwnableNumber
    {
        get
        {
            return ownableNumber;
        }
    }
}
