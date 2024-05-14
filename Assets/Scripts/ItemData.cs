using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",
    menuName = "ScriptableObjects/Item",
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

    [SerializeField] Sprite icon;
    public Sprite Icon
    {
        get
        {
            return icon;
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
