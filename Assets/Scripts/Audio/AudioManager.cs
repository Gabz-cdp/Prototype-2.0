using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; //static variable = shared by all scripts in the game

    [SerializeField] private AudioSource soundeffects;
    [SerializeField] public AudioClip eat;
    [SerializeField] public AudioClip find;

    private void Awake() //Awake = fires BEFORE the start method
    {
        if (Instance != null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //stays for the switching of scenes
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        Eat();
        FindItem();
    }*/

    public void Eat()
    {
        soundeffects.clip = eat;
        soundeffects.Play();
        Debug.Log("lol");

    }

    public void FindItem()
    {
        soundeffects.clip = find;
        soundeffects.Play();
    }
}
