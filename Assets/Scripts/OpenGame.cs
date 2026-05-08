using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGame : MonoBehaviour
{
    public GameObject JournalMenu;

    void Start()
    {
        if(JournalMenu != null)
        {
            JournalMenu.SetActive(true);
        }
    }
}
