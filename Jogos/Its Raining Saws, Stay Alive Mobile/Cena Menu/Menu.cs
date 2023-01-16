using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;

public class Menu : MonoBehaviour
{
    // === Painel Conquistas ===

    public      GameObject      painelConquistas;
    private     bool            _conquistasAtivado;

    // conquistas

    public      int     desviouDeMilSerras;
    public      int     coletouMilMoedas;
    public      int     sobrevivaPorXminutos;

    // Texto 

    public Text _textoConquistas;

    // imagens check conquistas
    [Header("Checks conquistas")]

    public      GameObject[]    imagensChecksMoedas;
    public      GameObject[]    imagensChecksSerras;
    public      GameObject[]    imagensChecsTempoSobrevido;

    // Trofeu

    public GameObject imagemDoTrofeu;

    // ===================================================

    // === Painel Como Jogar ===

    public      GameObject  painelComoJogar;
    private     int         _tutorialComoJogar;

    // ===================================================

    // === Painel Conquistas ===

    public GameObject      painelCreditos;
    private     bool        _creditosAtivado;

    // ===================================================

    // Start is called before the first frame update
    void Start()
    {
        // Iniciando o jogo em volocidade normal
        Time.timeScale  =   1f;

        // Inicializando as variavies que verificam se o painel esta ativo
        _creditosAtivado    =   false;
        _conquistasAtivado  =   false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotaoStart()
    {
        if(PlayerPrefs.GetInt("TutorialComoJogar") == 0)
        {
            painelComoJogar.SetActive(true);

            PlayerPrefs.SetInt("TutorialComoJogar", 1);
        }
        else
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    public void BotaoCreditos()
    {
        if(_creditosAtivado == false)
        {
            painelCreditos.SetActive(true);

            _creditosAtivado = !_creditosAtivado;
        }
        else
        {
            painelCreditos.SetActive(false);

            _creditosAtivado = !_creditosAtivado;
        }
    }

    public void BotaoSairDoJogo()
    {
        Application.Quit();

        Debug.Log("Saiu do jogo");
    }

    public void BotaoConquistas()
    {
        if(_conquistasAtivado == false)
        {
            painelConquistas.SetActive(true);

            Debug.Log("Moedas " + PlayerPrefs.GetInt("ConquistaMoedas"));
            Debug.Log("Serras " + PlayerPrefs.GetInt("ConquistaSerras"));
            Debug.Log("Tempo  " + PlayerPrefs.GetInt("ConquistaSobreviva"));

            // verificando se conquista moeda foi desbloqueada
            if(PlayerPrefs.GetInt("ConquistaMoedas", 0) == 1)
            {
                imagensChecksMoedas[0].SetActive(true);
            }

            // verificando se a conquista serras foi desbloqueada
            if(PlayerPrefs.GetInt("ConquistaSerras", 0) == 1)
            {
                imagensChecksSerras[0].SetActive(true);
            }

            // verificando se a consquista sobrevivo por X tempo foi desbloqueada
            if(PlayerPrefs.GetInt("ConquistaSobreviva", 0) == 1)
            {
                imagensChecsTempoSobrevido[0].SetActive(true);
            }

            if(PlayerPrefs.GetInt("ConquistaMoedas") == 1 && PlayerPrefs.GetInt("ConquistaSerras") == 1 && PlayerPrefs.GetInt("ConquistaSobreviva") == 1)
            {
                imagemDoTrofeu.SetActive(true);
            }

            _conquistasAtivado = !_conquistasAtivado;
        }
        else
        {
            painelConquistas.SetActive(false);

            _conquistasAtivado = !_conquistasAtivado;
        }
    }

    public void BotaoContinuar()
    {
        SceneManager.LoadScene("Jogo");
    }
}

