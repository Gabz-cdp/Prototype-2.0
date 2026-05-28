using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler //an interface that allows the script to detect when the pointer clicks on it
{
    //===========ITEM DATA=========//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull; //tracks if slot is full
    public string itemDescription;
    public Sprite emptySprite; //makes the slot blank

    [SerializeField]
    private int maxNumberOfItems; //Defines the size of the slot


    //===========ITEM SLOT=========//
    [SerializeField]
    public TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //==========COBWEB DEER===========//
    public GameObject animal;

    //===========ITEM DESCRIPTION SLOT============//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    //==========SELECTED ITEMS=============//
    public GameObject selectedShader;
    public bool thisItemSelected;

    //===AUDIO===
    //[SerializeField] private AudioManager audioManager; //Redundent

    private InventoryManager inventoryManager; //enables this script to talk to the InventoryManager


    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void Testing()
    {
        Debug.Log("Testing");
    }
    
   public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check to see if the slot is already full
        if (isFull)
            return quantity;

        //Update NAME
        this.itemName = itemName;

        //Update IMAGE
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update DESCRIPTION
        this.itemDescription = itemDescription;

        //Update QUANTITY
        this.quantity += quantity; //Adds the new quantity onto the old one
        if (this.quantity >= maxNumberOfItems) //if you have more items than the slot can hold, it is now FULL
        {
            quantityText.text = maxNumberOfItems.ToString(); // Indicates the capped stack.
            quantityText.enabled = true;
            isFull = true;

            /*//====OLDER CODE LOGIC==== 
            //quantityText.text = quantity.ToString(); //changes the interger to a string

            // Return the LEFTOVERS
            int extraItems = this.quantity - maxNumberOfItems; //Calculates the extra items from the capped value with the amount collected
            this.quantity = maxNumberOfItems; //Slot is equal to the capped value
            return extraItems; //checks to see if there is space in another slot for the excess items*/
        }

        //Update QUANTITY TEXT
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0; //how many leftovers there are if the items fit into the slot without an excess amount 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        /*if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }*/
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            //When selected and then clicked again with recognise that its selected and use the item
            bool usuable = inventoryManager.UseItem(itemName); //Checks to see if the health item is useable by crossreferencing the ItemSO script
            if(usuable)
            {
                this.quantity -= 1; //quantity decreases by 1 after each use
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
            //Highlights the Slot when Selected
            inventoryManager.DeselectAllSlots(); //Deselects all other slots 
            selectedShader.SetActive(true); //will turn Shader on
            thisItemSelected = true;

            //Updates description Panel
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite != null ? itemSprite : emptySprite;

            //====OLDER CODE LOGIC==== 
            //itemDescriptionImage.sprite = itemSprite;
            /*if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }

            if(itemDescriptionImage.sprite == null)
           {
               itemDescriptionImage.sprite == emptySprite;
           }*/
        }
    }

    private void EmptySlot()
    {
        //Zero out the slot so nothing shows in the slot menu or the description menu
        //====SLOT MENU====
        quantityText.enabled = false; //turns off the text 
        itemImage.sprite = emptySprite; //turns off the item slot

        //====DESCRIPTION MENU====  
        //turns off the description image, name, and text
        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {
        /*//======DROPPING ITEM TO HEAL COBWEBDEER======//
        // Find the animal
        GameObject animal = GameObject.FindGameObjectWithTag("Animal");
        if (animal != null)
        {
            PlayerHealth currentHealth = animal.GetComponent<PlayerHealth>();
            if (currentHealth != null)
            {
                // Heal immediately when item is dropped
                int currentAmount = 1; // you can make this depend on the item type
                currentHealth.ChangeHealth(currentAmount);

                //Play Eat Sound
                AudioManager.Instance.Eat();
            }
        }

        // Subtract the item from inventory
        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
        {
            EmptySlot();
        }
        //============================================//

        //REMOVING ITEM FROM INVENTORY AND SPWANING IN GAME WORLD
        //Create a new item
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>(); //can hold data about what type of item is it
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;

        //Create and modify the sprite renderer(SR)
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5; //the layer that is above the player
        //sr.sortingLayerName = "Ground"; //if you have a labeled layer

        //Add a collider
        itemToDrop.AddComponent<CapsuleCollider2D>();

        //Set the Location
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1, 0, 0); //excess item spawns next to the player

        //Subtract the item
        this.quantity -= 1; //quantity decreases by 1 after each use
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
        {
            EmptySlot();
        }

        // Get player position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dropPosition = player.transform.position + Vector3.right; // drop slightly to the side

        // Tell InventoryManager to spawn the item back into the world
        inventoryManager.DropItem(this, dropPosition);*/
    }

    public void Clear()
    {
        //Reset Quantity
        itemName = "";
        quantity = 0;
        itemSprite = null;
        itemDescription = "";
        isFull = false;

        // Reset UI
        itemImage.sprite = emptySprite;
        quantityText.text = "";
        quantityText.enabled = false;
        selectedShader.SetActive(false);
        thisItemSelected = false;
    }
}