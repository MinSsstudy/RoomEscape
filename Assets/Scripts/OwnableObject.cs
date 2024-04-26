using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnableObject : InteractableObject
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Mesh[] meshes;
    [SerializeField] int number = 1;

    
    public void TakeObject()
    {
        if (number > 0)
        {
            number--;
            meshFilter.mesh = meshes[number];
        }
    }
}
