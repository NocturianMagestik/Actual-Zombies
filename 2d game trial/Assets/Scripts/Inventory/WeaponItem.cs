﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponItem : Item
{
    public int Damage;
    public override void Use()
    {
        base.Use();
        
    }
}
