using UnityEngine;

public class OpenGame : MonoBehaviour
{
    public GameObject JournalMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(JournalMenu != null)
        {
            JournalMenu.SetActive(true);
        }
    }
}
