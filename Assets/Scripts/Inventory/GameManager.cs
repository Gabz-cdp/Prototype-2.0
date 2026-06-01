using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Singleton Pattern: instance(a name that reminds us there should only be one "instance" of this)/ static(there can only be one of them in a scene)

    [Header("Persistent Objects")]
    public GameObject[] persistentObjects;


    private void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            Destroy(gameObject);
            return;
        }
        else
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject); //DontDestroyOnLoad: object will persist when we move between scenes
            MarkPersistentObjects();
        }
    }


    private void MarkPersistentObjects()
    {
        foreach (GameObject obj in persistentObjects)
        {
            if (obj != null) //checks to see that all lines are filled with an object
            {
                DontDestroyOnLoad(obj);
            }
        }
    }


    private void CleanUpAndDestroy() //destroys the duplicates
    {
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
