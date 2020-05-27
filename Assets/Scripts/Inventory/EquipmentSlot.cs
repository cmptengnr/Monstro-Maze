using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : itemSlot
{
    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
    }

}
