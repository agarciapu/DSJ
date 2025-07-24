using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript4 : MonoBehaviour
{
    public void Setup(int score){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Nivel4");
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}
