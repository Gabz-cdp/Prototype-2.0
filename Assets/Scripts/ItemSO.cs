using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //Allows you to create instances of this scriptable object by clicking "Create" in Unity
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange(); //Allows the player to access this enum in the Inspector
    public int amountToChangeStat;

    public AttributesToChange attributesToChange = new AttributesToChange();
    public int amountToChangeAttributes;


    public bool UseItem()
    {
        /* if(statToChange == StatToChange.health) //have to create one for each type of stat
        {
            PlayerHealth playerHealth = GameObject.Find("HealthManager").GetComponent<PlayerHealth>(); //reference to the PlayerHealth 
            if(playerHealth.currentHealth == playerHealth.maxHealth) //checking to see if the health bar is already full
            {
                return false;
            }
            else
            {
                playerHealth.RestoreHealth(amountToChangeStat); //restores player health   
                return true;
            }    
            //GameObject.Find("HealthManager").GetComponent<PlayerHealth>().ChangeHealth(amountToChangeStat); //this is for the health system created - must link to own game
        } */
        return false; 
    }

    public enum StatToChange //Enumerations(enum): Allow to create drop-down menus of related constants
    {
        none,
        health //what you want to change when the item is used
    };

    public enum AttributesToChange //How much the health increases by
    {
        none,
        strength,
        agility
    };
}
