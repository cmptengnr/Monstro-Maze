using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mira.CharacterStats;

public class Character : MonoBehaviour
{
    public CharacterStats health;
    public CharacterStats strength;
    public CharacterStats keys;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanelScript statPanel;

    private void Awake()
    {
            statPanel.SetStats(health, strength, keys);
         statPanel.UpdateStatValues();
            
         inventory.OnItemRightClickedEvent += EquipFromInventory;
         equipmentPanel.OnItemRightClickedEvent += UnEquipFromEquipPanel;
         inventory.init();
         equipmentPanel.init();
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
            
        }
    }


   public void UnEquipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    
                   inventory.AddItem(previousItem);
                   previousItem.Unequip(this);
                   statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
            
        }
    }
}
