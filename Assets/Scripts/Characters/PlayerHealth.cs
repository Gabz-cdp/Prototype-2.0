using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //====HEALTH SLIDER====
    public int currentHealth;
    public float maxHealth;
    public Slider slider;

    //===PLAYER FEEDBACK===
    public Image popUp;

    //add gameobject that has item script - Andy
    //====HEALTH ITEM====
    public GameObject MaggotApple;
    //public bool hasApple = false; //Already in the Item script

    //=====POPUPS=====
    public GameObject popUpDamagePrefab; //health pop of deer when fed
    public GameObject popUpBox; //Pop up for healing the deer
    public Animator animator;
    public TMP_Text popUpText;
    public string popUpDialogue;

    //==MAGGOT APPLE ITEM SCRIPT==
    [SerializeField] public Item item;

    void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        //hasApple = false; //already in the Item script
        popUpBox.SetActive(false);
    }
    void Update()
    {
        slider.value = currentHealth;

        if (currentHealth >= 3)
        {
            popUp.gameObject.SetActive(true);
        }
        else if (currentHealth < 3)
        {
            popUp.gameObject.SetActive(false);
        }

        //locating the maggot apple from the item script
        /*if (item != null)
        {
            if (item.hasApple)
            {
                //
            }
        }*/
    }
    public void ChangeHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //(col.gameObject.tag == "MaggotApple") - collison with apple //&& (item.hasApple = true)
        if (col.gameObject.name == "Willow") //&& bool for hasApple that is persistent across scenes + include the flag of the maggot apple - Andy
        {
            currentHealth++;
            Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity); //health pop of +1 every time the deer is healed
            PlayerHealth pop = GetComponent<PlayerHealth>(); //Popup dialogue for feeding deer
            pop.PopUp(popUpDialogue);//part of line above's logic

            /*if(hasApple)
            {
            }*/
        }
        /*else if (col.gameObject.name == "Willow" && (item.hasApple = false))
        {
            //Add popup saying more apples needed
        }*/
    }

    //PopUp Controller 
    public void PopUp(string text)
    {
        popUpDamagePrefab.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }

}
