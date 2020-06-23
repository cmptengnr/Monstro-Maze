using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color emptycolor;
    [SerializeField] KeyCode itemPickupKeycode = KeyCode.E;


    private bool isInRange;
    private bool isEmpty;

    private void OnValidate()
    {

        if(inventory == null)
        inventory = FindObjectOfType<Inventory>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = item.icon;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(itemPickupKeycode))
        {
            if(!isEmpty)
            {
                inventory.AddItem(item);
                isEmpty = true;
                spriteRenderer.color = emptycolor;
            }
             
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            spriteRenderer.enabled = false;
        }
    }
}
