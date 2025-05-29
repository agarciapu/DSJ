
using UnityEngine;

public class Cup : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("+1");
            GameManager.Instance.AddScore(1);
        }
    }
	
}
