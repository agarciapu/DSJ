using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuestionario : MonoBehaviour
{
    public GameObject correcto;    
    public GameObject incorrecto;
    public GameObject final;   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("opcion1"))
        {
             StartCoroutine(MostrarTextoIncorrecto(incorrecto)); 
            
        }
        else if (collision.gameObject.CompareTag("opcion2"))
        {
              StartCoroutine(MostrarTextoTemporal(correcto)); 
           
            
          
        } else if(collision.gameObject.CompareTag("opcion3"))
        {
            StartCoroutine(MostrarTextoIncorrecto(incorrecto)); 
            
        } else if(collision.gameObject.CompareTag("opcion4")){
            StartCoroutine(MostrarTextoTemporal(correcto)); 
           
        } else if(collision.gameObject.CompareTag("opcion5")) {
            StartCoroutine(MostrarTextoIncorrecto(incorrecto)); 
        } else if(collision.gameObject.CompareTag("opcion6")){
             StartCoroutine(MostrarTextoTemporal(correcto)); 
        } else if(collision.gameObject.CompareTag("opcion7")){
        StartCoroutine(MostrarTextoIncorrecto(incorrecto)); 
        } else if(collision.gameObject.CompareTag("opcion8")){
          StartCoroutine(MostrarTextoTemporal(correcto)); 
        } else if(collision.gameObject.CompareTag("opcion9")){
          StartCoroutine(MostrarTextoIncorrecto(final)); 
        }
    }

    IEnumerator MostrarTextoTemporal(GameObject objetoUI)
    {
        objetoUI.SetActive(true);      
        yield return new WaitForSeconds(3f);
        objetoUI.SetActive(false);      
    }

    IEnumerator MostrarTextoIncorrecto(GameObject objetoUI)
    {
        objetoUI.SetActive(true);     
        yield return null;
       
    }
}