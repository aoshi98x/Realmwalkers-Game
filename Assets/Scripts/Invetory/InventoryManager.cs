using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public  ItemSlot[ ] itemSlot;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {

            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite ,string ItimDescrpt)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name ==name|| itemSlot[i].quantity == 0)
            {

                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, ItimDescrpt);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, ItimDescrpt);
                 return leftOverItems;
            }

        }
        return quantity;
    }
    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].SelectedShader.SetActive(false);
             itemSlot[i].thisItemSelcted = false;
        }
    }
}
