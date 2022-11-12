using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // === Audio Source ===

    [SerializeField]
    private AudioSource _somDaMoeda;

    [SerializeField]
    private AudioSource _musicaDeGameOver;

    [SerializeField]
    private AudioSource _musicaDoJogo;

    // === Sitema de mutar ===

    [SerializeField]
    private bool _mutarJogoAtivado;

    // posição 0 volume ligado | posiçõa 1 volume desligado
    [SerializeField]
    private GameObject[] _botaoMutar;

    // === Game Over ===

    [SerializeField]
    private GameObject _menuGameOver;

    public bool gameOverAtivado = false;

    // === Moedas ===

    // variavel que armazena quantidade de moedas coletadas
    [SerializeField]
    private int _moedasColetadas;

    // Painel com imagme e texto das moedas em jogo
    [SerializeField]
    private GameObject _painelDisplayDoJogo;

    // texto moedas canvas
    [SerializeField]
    private Text _textoMoedasUI;

    // === Estatisticas ===

    [SerializeField]
    private Text _textoMoedasColetadas;
    [SerializeField]
    private Text _textoHighScoreMoedas;

    // === Pausa ===

    [SerializeField]
    private GameObject _menuPausa;

    private bool _jogoPausado = false;

    // === Parabens pelo novo recorde ===

    [SerializeField]
    private GameObject[] _parabensPeloNovoRecorde;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Atribuindo valores ao iniciar o jogo
        _moedasColetadas = 0;
        _textoMoedasUI.text = "X " + _moedasColetadas;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();
    }

    // incrementa em 1 as moedas coletadas e atualiza o UI
    public void AcrecentarMoeda()
    {
        // incrementa a quantidade de moedas
        _moedasColetadas++;

        // toca o som de coleta da moeda
        _somDaMoeda.Play();

        // atualiza o texto UI
        _textoMoedasUI.text = "X " + _moedasColetadas;
    }

    public void GameOver()
    {
        gameOverAtivado = true;

        // Desativa a musica do jogo
        _musicaDoJogo.Pause();

        // Toca a musica de Game Over
        _musicaDeGameOver.Play();

        // desativa o display do jogo
        _painelDisplayDoJogo.SetActive(false);

        // Ativando o menu de Game Over
        _menuGameOver.SetActive(true);

        // Pausando o jogo
        Time.timeScale = 0f;

        // atualizando variaveis
        _textoMoedasColetadas.text = "Collected Coins = " + _moedasColetadas;

        // checando se é maior que o high score e atualizando 
        if (_moedasColetadas > PlayerPrefs.GetInt("_highScoreMoedas"))
        {
            SalvarPontuacao();

            // mostra os parabens e as bexigas 
            BateuRecorde();
        }

        // mostrando HighScore na tela
        _textoHighScoreMoedas.text = "High Score = " + PlayerPrefs.GetInt("_highScoreMoedas");
    }

    private void Pausa()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_jogoPausado == false)
            {
                // ativa o menu de pausa
                _menuPausa.SetActive(true);

                // congela o jogo
                Time.timeScale = 0f;

                // musica do jogo
                _musicaDoJogo.Stop();

                // muda o valor da variavel boleana
                _jogoPausado = true;
            }
            else
            {
                // desativa o menu de pausa
                _menuPausa.SetActive(false);

                // descongela o jogo
                Time.timeScale = 1f;

                // ativa a musica do jogo
                _musicaDoJogo.Play();

                // muda o valor da variavel boleana
                _jogoPausado = false;
            }
        }
    }

    // Ativa ou desativa os efeitos sonoros 
    public void EfeitosSonoros()
    {
        if(_mutarJogoAtivado == false)
        {
            // desativa o botão de som ligado e ativa o botão som desligado
            _botaoMutar[0].SetActive(false);
            _botaoMutar[1].SetActive(true);

            // mudando o valor da variavel para verdadeiro
            _mutarJogoAtivado = true;

            _somDaMoeda.volume = 0;
            _musicaDoJogo.volume = 0;
            _musicaDeGameOver.volume = 0;
        }
        else
        {
            // desativa o botão de som desligado e ativa o botão de som ligado
            _botaoMutar[1].SetActive(false);
            _botaoMutar[0].SetActive(true);

            // mudando o valor da variavel para falso
            _mutarJogoAtivado = false;

            _somDaMoeda.volume = 0.5f;
            _musicaDoJogo.volume = 0.5f;
            _musicaDeGameOver.volume = 0.5f;

        }
        
    }
    
    // salva a pontuação do jogador
    private void SalvarPontuacao()
    {
        PlayerPrefs.SetInt("_highScoreMoedas", _moedasColetadas);
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BateuRecorde()
    {
        _parabensPeloNovoRecorde[0].SetActive(true);
        _parabensPeloNovoRecorde[1].SetActive(true);
    }
}
