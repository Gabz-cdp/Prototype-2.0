using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;
    public Slot resultSlot;

    void Start()
    {
        // Initialize list with empty slots
        itemList = new List<Item>(new Item[craftingSlots.Length]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);

                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach (Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }

                if (nearestSlot != null)
                {
                    Image slotImage = nearestSlot.GetComponent<Image>();
                    Image itemImage = currentItem.GetComponent<Image>();

                    if (slotImage != null && itemImage != null)
                    {
                        slotImage.enabled = true;
                        slotImage.sprite = itemImage.sprite;
                    }

                    nearestSlot.item = currentItem;
                    itemList[nearestSlot.index] = currentItem;
                }

                currentItem = null;

                CheckForCreatedRecipes();
            }
        }
    }

    void CheckForCreatedRecipes()
    {
        Image resultImage = resultSlot.GetComponent<Image>();

        // Clear result slot
        resultImage.enabled = false;
        resultImage.sprite = null;
        resultSlot.item = null;

        string currentRecipeString = "";

        foreach (Item item in itemList)
        {
            currentRecipeString += (item != null) ? item.itemName : "null";
        }

        Debug.Log("Current Recipe: " + currentRecipeString);

        for (int i = 0; i < recipes.Length; i++)
        {
            Debug.Log("Checking against: " + recipes[i]);

            if (recipes[i] == currentRecipeString)
            {
                Debug.Log("Recipe matched!");

                Image resultItemImage = recipeResults[i].GetComponent<Image>();

                if (resultItemImage != null)
                {
                    resultImage.enabled = true;
                    resultImage.sprite = resultItemImage.sprite;
                }

                resultSlot.item = recipeResults[i];
                return;
            }
        }
    }

    public void OnMouseDownItem(Item item)
    {
        if (currentItem == null)
        {
            currentItem = item;

            Image itemImage = currentItem.GetComponent<Image>();

            if (itemImage != null)
            {
                customCursor.gameObject.SetActive(true);
                customCursor.sprite = itemImage.sprite;
            }
        }
    }
}
