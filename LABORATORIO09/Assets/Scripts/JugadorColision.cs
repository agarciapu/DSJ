using UnityEngine;

public class JugadorColision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ugg"))
        {
            AI npcAI = collision.gameObject.GetComponent<AI>();
            if (npcAI != null)
            {
                npcAI.DetenerIA(); // Llama al método que detiene la IA
            }
        }
    }
}
