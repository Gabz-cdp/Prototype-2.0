using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; //Link to the toggle of the inventory menu
    private bool menuActivated; //tracks when the menu is opened or closed
    public ItemSlot[] itemSlot; //Add square brackets to make ItemSlot an array

    public ItemSO[] itemSOs; //Array to add as many items as we want + make a list for all scriptable items

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated) //if the button is pressed and the menu is already open
        {
            Time.timeScale = 1; //deactivates the time in unity
            InventoryMenu.SetActive(false); //Deactives the menu
            menuActivated = false;
        }
        else //only executes if the previous statement is NOT true
        if (Input.GetKeyDown(KeyCode.E) && !menuActivated) //if the button is pressed and the menu is not open - (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0; //pauses time in unity
            InventoryMenu.SetActive(true); //Activates the menu
            menuActivated = true;
        }
    }

    public GameObject itemPrefab; // assign your item prefab in Inspector

    public void DropItem(ItemSlot slot, Vector3 dropPosition)
    {
        if (slot.isFull)
        {
            // Spawn item prefab at player position
            GameObject droppedItem = Instantiate(itemPrefab, dropPosition, Quaternion.identity);

            // Configure its Item script with slot data
            Item itemScript = droppedItem.GetComponent<Item>();
            itemScript.SetItemData(slot.itemName, slot.quantity, slot.itemSprite, slot.itemDescription);

            // Clear the slot
            slot.Clear();
            //RefreshUI();
        }
    }

    public bool UseItem(string itemName) //Is called when the player clicks on the item in the item slot //(string itemName) will search through the scriptable objects to find the one that matches
    {
        for (int i = 0; i < itemSOs.Length; i++) //checks the entire array
        {
            if (itemSOs[i].itemName == itemName) //checks to see if the itemName is in the first slot, if not it cycles through until its found
            {
                bool usuable = itemSOs[i].UseItem(); //checks to see if the item used can fill the health bar up, if its full it returns the excess items
                return usuable;
            }
        }
        return false;
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) //int = to return the values
    {
        //test check
        //Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemSprite" + itemSprite);
        
        for (int i = 0; i < itemSlot.Length; i++)
        {
            int remaining = quantity;

            if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)) 
                //(itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0) //checking to see if there are leftovers
                {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems <= 0)
                    return 0; // all items placed

                //====OLDER CODE LOGIC====
                /*if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);*/
                //return leftOverItems; //returns how many left over items there are
            }
        }
        return quantity; //if there are too many items in one slot it returns the excess items to the map (drops it)
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
