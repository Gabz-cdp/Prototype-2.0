using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "CobwebDeer")
       {
           Destroy(gameObject);
        }   
    }
}
