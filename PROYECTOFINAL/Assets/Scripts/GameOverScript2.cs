using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript2 : MonoBehaviour
{
    public void Setup(int score){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Nivel2");
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}
