using System;
using UnityEngine;

public class FeedDeer : MonoBehaviour
{
    private ItemSlot itemSlot;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemSlot = GetComponent<ItemSlot>();

            itemSlot.OnRightClick();
        }    
    }
}
