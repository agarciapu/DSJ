using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pase5 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jupiter"))
        {
            Debug.Log("Nivel 5 COMPLETADO - Cargando Nivel 6");

            // Cargar la escena llamada "Nivel3" (que es tu Nivel 1)
            SceneManager.LoadScene("Nivel6");
        }
    }
}