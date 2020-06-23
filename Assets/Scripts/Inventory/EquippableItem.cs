using Mira.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipmentType
{
    weapon,
    torch,
    key,

}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int Strength;
    public int Health;
    public int Keys;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character c)
    {
        if (Strength != 0)
        c.strength.AddModifier(new StatModifier(Strength, StatModType.Flat, this));
        if (Health != 0)
        c.health.AddModifier(new StatModifier(Health, StatModType.Flat, this));
        if (Keys != 0) 
        c.keys.AddModifier(new StatModifier(Keys, StatModType.Flat, this));

    }

    public void Unequip(Character c)
    {
        c.strength.RemoveAllModifiersFromSource(this);
        c.health.RemoveAllModifiersFromSource(this);
        c.keys.RemoveAllModifiersFromSource(this);

    }
}
