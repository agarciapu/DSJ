using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pase6 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Saturno"))
        {
            Debug.Log("Nivel 6 COMPLETADO - Cargando Nivel 7");

            // Cargar la escena llamada "Nivel3" (que es tu Nivel 1)
            SceneManager.LoadScene("Nivel7");
        }
    }
}