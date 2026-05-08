using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-1);
        }

        if (collision.gameObject.name == "CobwebDeer")
        { 
            gameObject.SetActive(false);
        }
    }
}
