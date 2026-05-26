using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject JournalMenu;
    public GameObject MapMenu;
    public GameObject MainMenu;

    [SerializeField]
    private bool menuActivated;//tracks when the menu is opened or closed

    void Start()
    {
        menuActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        //====JOURNAL MENU====//
        if (Input.GetKeyDown(KeyCode.J) && menuActivated) //if the button is pressed and the menu is already open
        {
            //test check
            //Debug.Log("Not Active");
            Time.timeScale = 1; //deactivates the time in unity
            JournalMenu.SetActive(false); //Deactives the menu
            menuActivated = false;
        }
        else //only executes if the previous statement is NOT true
       if (Input.GetKeyDown(KeyCode.J) && !menuActivated) //if the button is pressed and the menu is not open - (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            //test check
            //Debug.Log("Active");
            Time.timeScale = 0; //pauses time in unity
            JournalMenu.SetActive(true); //Activates the menu
            menuActivated = true;
        }


        //====MAP MENU====//
        if (Input.GetKeyDown(KeyCode.M) && menuActivated) //if the button is pressed and the menu is already open
        {
            Time.timeScale = 1; //deactivates the time in unity
            MapMenu.SetActive(false); //Deactives the menu
            menuActivated = false;
        }
        else //only executes if the previous statement is NOT true
       if (Input.GetKeyDown(KeyCode.M) && !menuActivated) //if the button is pressed and the menu is not open - (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0; //pauses time in unity
            MapMenu.SetActive(true); //Activates the menu
            menuActivated = true;
        }


        //====MAIN MENU====//
        if (Input.GetKeyDown(KeyCode.Escape) && menuActivated) //if the button is pressed and the menu is already open
        {
            Time.timeScale = 1; //deactivates the time in unity
            MainMenu.SetActive(false); //Deactives the menu
            menuActivated = false;
        }
        else //only executes if the previous statement is NOT true
      if (Input.GetKeyDown(KeyCode.Escape) && !menuActivated) //if the button is pressed and the menu is not open - (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0; //pauses time in unity
            MainMenu.SetActive(true); //Activates the menu
            menuActivated = true;
        }
    }
}
