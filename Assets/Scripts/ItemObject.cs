using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : InteractableObject
{    
    [SerializeField] protected ItemData itemData;
    public ItemData Item
    {
        get
        {
            return itemData;
        }
    }

    int numOfItem;
    public int NumberOfItem
    {
        get
        {
            return numOfItem;
        }
    }

    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Mesh[] meshes;


    protected override void Start()
    {
        base.Start();

        numOfItem = itemData.OwnableNumber;
    }

    public override void Interact()
    {
        if (Item.IsOwnable)
        {
            TakeItem();
            PlayerData.Instance.inventory.InsertItem(Item);
        }
    }

    void TakeItem()
    {
        if (numOfItem > 0)
        {
            numOfItem--;
            meshFilter.mesh = meshes[numOfItem];
        }
    }
}
