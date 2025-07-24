using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pase7 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Urano"))
        {
            Debug.Log("Nivel 7 COMPLETADO - Cargando Nivel 8");

            // Cargar la escena llamada "Nivel3" (que es tu Nivel 1)
            SceneManager.LoadScene("Nivel8");
        }
    }
}