using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // === Contagem Regressiva ===

    private      int         _tempoReferencia;
    private      float       _tempoAtual;

    //======================================================

    // === Velocidade Jogador, Serra e Moedas ===

    public       float       velocidadeDoJogador;
    public       float       velocidadeDaMoeda;
    public       float       velocidadeDaSerra;

    //======================================================

    // === Gerenciador de Surgimento ===

    public bool autorizarSurgimento;

    // frequencia em segundos de aparição

    public     float   _tempoSerra;
    public     float   _tempoMoeda;

    //======================================================

    // === Escrevendo Faster na Tela ===

    public      TMPro.TMP_Text      fasterTextoUI;
    public      float               esperar;
    public      string              escreva;

    //======================================================

    // === Coletando moedas ===

    private     int             _moedasColetadas;
    private     bool            _somMoedaAtivo;
    public      Text            moedasColetadasUI;

    //======================================================

    // === Escrevendo Faster na Tela ===

    private     bool            _pauseAtivo;
    public      GameObject      painelPause;

    //======================================================

    // === Botão volume ===

    private     bool            _somAtivado;
    public      GameObject      imagemSomAtivado;
    public      GameObject      imagemSomDesativado;

    //======================================================

    // === Sons do jogo ===

    [Header("Sons do Jogo")]

    public      AudioSource     somMoedaColetada;
    public      AudioSource     musicaDoJogo;
    public      AudioSource     musicaGameOver;
    public      AudioSource     somAumentoVelocidade;

    //======================================================

    // === Game Over ===

    [Header("Game Over")]

    public      GameObject      painelGameOver;
    public      GameObject      textoNovoHighScore;
    public      Text            textoScore;
    public      Text            textoHighScore;


    //======================================================

    // === Conquistas ===

    private     int     _totalMoedasColetadas;
    private     int     _totalSerrasDesviadas;
    private     int     _serrasDesviadas;
    private     int     _sobrevivaDezMinutos;


    //======================================================

    // Start is called before the first frame update
    void Awake()
    {
        // referenciado este script para os demais
        GameManager.Instance  =  this;

        // iniciar o jogo após a pausa
        Time.timeScale      =   1f;

        // Atribuindo valor a variavel tempo
        _tempoReferencia    =   30;
        _tempoAtual         =   _tempoReferencia;


        // Atribuindo valor as variaveis de velocidade
        velocidadeDoJogador   =     2f;
        velocidadeDaSerra     =     2f;
        velocidadeDaMoeda     =     2f;

        // Atribuindo valor as variaveis do texto faster
        escreva    =  "FASTER!";
        esperar    =  0.2F;

        // Inicializando as variaveis para controle de surgimento
        autorizarSurgimento     =   true;
        _tempoSerra             =   2;
        _tempoMoeda             =   4;

        // inicializando contador de moedas
        _moedasColetadas        =   0;

        // iniciarlizar a variavel pause ativo
        _pauseAtivo     =   false;

        // iniciando a variavel som ativado
        _somAtivado     =   true;
    }

    // Update is called once per frame
    void Update()
    {
        AumentarDificuldade();
    }

    private void AumentarDificuldade()
    {
        // A cada contagem regressi aumenta a velocidade

        _tempoAtual -= Time.deltaTime;

        if(_tempoAtual <= 0)
        {
            // aumenta a velocidade dos gameObjects
            velocidadeDaMoeda       ++;
            velocidadeDaSerra       ++;
            velocidadeDoJogador     ++;
            _sobrevivaDezMinutos    ++;
            
            if(_sobrevivaDezMinutos >= 10)
            {
                _tempoSerra = 2;
                _tempoMoeda = 4;
            }

            // reseta o contador
            _tempoAtual = _tempoReferencia;


            StartCoroutine(EscreverFaster(escreva));
        }
    }

    IEnumerator EscreverFaster(string texto)
    {
        fasterTextoUI.text = "";

        somAumentoVelocidade.Play();

        for(int letra = 0; letra < texto.Length; letra++)
        {
            fasterTextoUI.text = fasterTextoUI.text + texto[letra];

            yield return new WaitForSeconds(esperar);
        }

        fasterTextoUI.text = "";
    }

    public void MoedaColetada()
    {
        _moedasColetadas++;

        somMoedaColetada.Play();

        moedasColetadasUI.text = "X " + _moedasColetadas;
    }

    public void BotaoPause()
    {
        if(_pauseAtivo == false)
        {
            painelPause.SetActive(true);

            musicaDoJogo.volume = 0f;

            Time.timeScale = 0f;

            _pauseAtivo = true;
        }
        else
        {

            painelPause.SetActive(false);

            musicaDoJogo.volume = 0.5f;

            Time.timeScale = 1f;

            _pauseAtivo = false;
        }
    }

    public void BotaoSom()
    {
        if(_somAtivado == true)
        {
            _somAtivado = false;

            imagemSomAtivado.SetActive(false);
            imagemSomDesativado.SetActive(true);

            somMoedaColetada.volume         =   0f;
            musicaDoJogo.volume             =   0f;
            musicaGameOver.volume           =   0f;
            somAumentoVelocidade.volume     =   0f;
        }
        else
        {
            _somAtivado = true;

            imagemSomAtivado.SetActive(true);
            imagemSomDesativado.SetActive(false);

            somMoedaColetada.volume         =   0.5f;
            musicaDoJogo.volume             =   0.5f;
            musicaGameOver.volume           =   0.5f;
            somAumentoVelocidade.volume     =   0.5f;

        }
    }

    public void BotaoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BotaoJogarNovamente()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void BotaoSairJogo()
    {
        Application.Quit();

        Debug.Log("Saiu do jogo");
    }

    public void GameOver()
    {
        // Para o surgimento de novos itens 
        autorizarSurgimento = false;

        // Parando musica do jogo e tocando musica game over
        musicaDoJogo.Stop();
        musicaGameOver.Play();

        // Ativando o painel Game Over
        painelGameOver.SetActive(true);

        // pausando o jogo
        Time.timeScale = 0f;

        // informando o Score atual e o HighScore
        textoScore.text = "SCORE = " + _moedasColetadas;

        if(_moedasColetadas > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _moedasColetadas);
        }

        textoHighScore.text = "HighScore = " + PlayerPrefs.GetInt("HighScore");

        SalvarConquistas();
        
    }

    public void SerrasDesviadas()
    {
        _serrasDesviadas++;

        Debug.Log("Serras desviadas " + _serrasDesviadas);
    }

    private void SalvarConquistas()
    {
        // ao chamar o game over ser enviado os dados para registro

        // Salvando totla de moedas coletadas
        _totalMoedasColetadas = PlayerPrefs.GetInt("TotalMoedas", 0);
        _totalMoedasColetadas += _moedasColetadas;
        PlayerPrefs.SetInt("TotalMoedas", _totalMoedasColetadas);

        if(PlayerPrefs.GetInt("TotalMoedas") >= 1000)
        {
            PlayerPrefs.SetInt("ConquistaMoedas", 1);
        }

        // Salvando quantidade de serras desviadas
        _totalSerrasDesviadas = PlayerPrefs.GetInt("TotalSerras", 0);
        _totalSerrasDesviadas = _serrasDesviadas;
        PlayerPrefs.SetInt("TotalSerras", _totalSerrasDesviadas);

        if(PlayerPrefs.GetInt("TotalSerras") >= 1000)
        {
            PlayerPrefs.SetInt("ConquistaSerras", 1);
        }


        // Verifica se o jogador sobreviveu por 10 minutos e salva o resultado
        if(_sobrevivaDezMinutos >= 20)
        {
            PlayerPrefs.SetInt("ConquistaSobreviva", 1);
        }
    }
}
