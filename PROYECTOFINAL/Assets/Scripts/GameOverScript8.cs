using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript8 : MonoBehaviour
{
    public void Setup(int score){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Nivel8");
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}
