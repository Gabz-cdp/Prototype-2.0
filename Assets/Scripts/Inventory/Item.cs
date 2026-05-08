using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] //Makes this variable visiable and editable in the Unity Inspector
    public string itemName; //priavte protects this variable from being accidentally edited by other scripts
   

    [SerializeField]
    public int quantity; //the amount of items collected

    [SerializeField]
    public Sprite sprite; //the image of the item
   
    
    [TextArea]
    [SerializeField]
    public string itemDescription;

    [SerializeField]
    public InventoryManager inventoryManager;

    private void Awake()
    {
        if (inventoryManager == null)
            inventoryManager = Object.FindAnyObjectByType<InventoryManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //the player collides with the object
        {
            //====OLDER CODE LOGIC====
            /*inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);*/

            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                //Destroy(gameObject); // item fully collected

                //Play FindItem Sound
                AudioManager.Instance.FindItem();
            }
            else
            {
                quantity = leftOverItems; //update remaining quantity
            }
        }
    }

    //Use this if at least one of the colliders has Is Trigger checked & This means the objects overlap without physical collision.
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            else
                quantity = leftOverItems;
        }
    }*/

    public void SetItemData(string name, int qty, Sprite sprite, string description)
    {
        itemName = name;
        quantity = qty;
        this.sprite = sprite;
        itemDescription = description;
    }
}
