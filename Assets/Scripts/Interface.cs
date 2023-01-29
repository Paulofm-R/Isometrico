using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    [SerializeField] GameObject painel;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject VitoriaText;

    public static bool gameover = false;
    public static bool vitoria = false;

    void Update()
    {   
        if(gameover){
            painel.SetActive(true);
            GameOverText.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(vitoria){
            painel.SetActive(true);
            VitoriaText.SetActive(true);
            Time.timeScale = 0f;
        }        
    }

    public void SairJogo(){
        Application.Quit();
    }

    public void ReiniciarJogo(){
        Time.timeScale = 1f;

        painel.SetActive(false);
        GameOverText.SetActive(false);
        VitoriaText.SetActive(false);

        gameover = false;
        vitoria = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}