using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pase3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tierra"))
        {
            Debug.Log("Nivel 3 COMPLETADO - Cargando Nivel 4");

            // Cargar la escena llamada "Nivel3" (que es tu Nivel 1)
            SceneManager.LoadScene("Nivel4");
        }
    }
}