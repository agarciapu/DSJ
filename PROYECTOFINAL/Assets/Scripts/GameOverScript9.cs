using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript9 : MonoBehaviour
{
    public void Setup(int score){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Nivel9");
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}
