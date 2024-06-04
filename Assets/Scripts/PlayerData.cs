using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>
{
    public Inventory inventory { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        inventory = new Inventory();
    }
}
