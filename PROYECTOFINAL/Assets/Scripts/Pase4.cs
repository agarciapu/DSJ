using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pase4 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marte"))
        {
            Debug.Log("Nivel 4 COMPLETADO - Cargando Nivel 5");

            // Cargar la escena llamada "Nivel3" (que es tu Nivel 1)
            SceneManager.LoadScene("Nivel5");
        }
    }
}