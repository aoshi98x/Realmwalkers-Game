using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //=======ITEM DATA======//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string ItmeDescrpt;
    public Sprite emptysprite;

    [SerializeField]
    private int maxNumberOfItems;
    //====ITEM SLOT====//
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;
    public GameObject SelectedShader;
    public bool thisItemSelcted;
    private InventoryManager inventoryManager;
    //==)==Item Slot Descr===//
    public Image itemDescriptionImagen;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptiontext;


    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string ItimDescript)
    {
        if (isFull)
            return quantity;
        //name
        this.itemName = itemName;

        //image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        //descr
        this.ItmeDescrpt = ItimDescript;
        //qua
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
            //return
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }
        //text
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        return 0;
       
      
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();

        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {

        inventoryManager.DeselectAllSlots();
        SelectedShader.SetActive(true);
       thisItemSelcted = true;
        ItemDescriptionName.text = itemName;
        ItemDescriptiontext.text = ItmeDescrpt;
        itemDescriptionImagen.sprite = itemSprite;
        if (itemDescriptionImagen.sprite == null)
         itemDescriptionImagen.sprite = emptysprite;


    }
    public void OnRightClick()
    {

    }
}

