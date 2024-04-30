using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    int curNumber;
    public int CurNumber
    {
        get
        {
            return curNumber;
        }
    }

    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Mesh[] meshes;


    protected override void Start()
    {
        base.Start();

        curNumber = itemData.OwnableNumber;
    }

    public void TakeItem()
    {
        if (curNumber > 0)
        {
            curNumber--;
            meshFilter.mesh = meshes[curNumber];
        }
    }
}
