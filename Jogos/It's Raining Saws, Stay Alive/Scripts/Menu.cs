using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuDeCreditos;

    private bool _creditosAtivado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Fase - 1");
    }

    public void MenuDeCreditos()
    {
        if(_creditosAtivado == false)
        {
            _menuDeCreditos.SetActive(true);

            // altera o valor da variavel
            _creditosAtivado = true;
        }
        else
        {
            _menuDeCreditos.SetActive(false);

            // altera o valor da variavel
            _creditosAtivado = false;
        }
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}
