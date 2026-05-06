using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = 1f;
    public Vector2 newPlayerPosition;
    private Transform player;


    private void OnTriggerEnter2D(Collider2D collision) //Fires anytime an object enters this trigger
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            fadeAnim.Play("FadeToBlack"); //every time the collider is triggered, the scene will fade to black
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade() //Add a Coroutine (works like a method, except that they can be paused) 
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(SceneToLoad);
    }
}
