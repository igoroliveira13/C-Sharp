using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI de  Game Over
    public GameObject gameOver;

    // Chances 
    public int chances = 3;

    // 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FimDeJogo();
        SairDoJogo();
        RecarregarCena();
    }

    void FimDeJogo()
    {
        if(chances <= 0)
        {
            // mostra game over na tela
            gameOver.SetActive(true);

            // pausa o jogo
            Time.timeScale = 0;
        }
    }

    void SairDoJogo()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RecarregarCena()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
