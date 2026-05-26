using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{                                                                      //static variables: will be shared by all objects that have the DontDestroy script on them
    private static GameObject[] persistentObjects = new GameObject[6]; //persistentObjects: creates an array with all the objects that we want to persist from scene to scene
    public int objectIndex; //objectindex: each persistent object gets its own number (eg: player will go in slot 1, inventory menu in slot 2, etc)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() //runs immidately before Start method
    {
        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject; //checks for duplicates and deletes them
            DontDestroyOnLoad(gameObject); //ensures that whatever the script is attached to it doesnt lose any information on scene swaps
        }

        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
