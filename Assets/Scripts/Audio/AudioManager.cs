using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; //static variable = shared by all scripts in the game

    [SerializeField] private AudioSource audioSource, eatSource, findSource;
    [SerializeField] public AudioClip backTrack; //variable names are lowercase
    [SerializeField] public AudioClip eat;
    [SerializeField] public AudioClip find;

    private void Awake() //Awake = fires BEFORE the start method
    {
        if (Instance != null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //stays for the switching of scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackTrack();
        Eat();
        FindItem();
    }

    public void BackTrack() //method names are uppercase
    {
        audioSource.clip = backTrack;
        audioSource.Play();
    }

    public void Eat()
    {
        eatSource.clip = eat;
        eatSource.Play();

    }

    public void FindItem()
    {
        findSource.clip = find;
        findSource.Play();
    }
}
