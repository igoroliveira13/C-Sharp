using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // armazena o panel de creditos 
    [SerializeField]
    GameObject _painelDeCreditos;

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
        // carrega primeira fase

        SceneManager.LoadScene("Fase 1");
    }

    public void Creditos()
    {
        // habilita o painel de creditos
        _painelDeCreditos.SetActive(true);
    }

    public void RetornarAoMenu()
    {
        // Desabilitar o painel de creditos
        _painelDeCreditos.SetActive(false);
    }
}
