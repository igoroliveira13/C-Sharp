using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Game Over
    public bool gameOverAtivado;
    [SerializeField]
    GameObject _painelGameOver;

    // Menu Pausa
    [SerializeField]
    GameObject _painelDePausa;
    private bool _jogoEstaPausado;

    // Pontuação do Jogador 
    private int _inimigosDerrotados;
    [SerializeField]
    private Text _textoPontosDoJogador;
    [SerializeField]
    private GameObject _textoDePontuacaoDoHUD;
    [SerializeField]
    private Text _pontuacaoFinal;
    [SerializeField]
    private Text _recorde;
    private string _bestScore;

    // UI de vidas do Jogador
    [SerializeField]
    private Sprite[] _spritesDeVidaHUD;
    [SerializeField]
    private Image _spriteAtual;
    [SerializeField]
    private GameObject _imagemNavesHUD;

    // danos na nave do jogador
    [SerializeField]
    private GameObject _danoMenor;
    [SerializeField]
    private GameObject _danoMaior;

    // destruir jogador e instanciar uma explosão no lugar
    public Transform objectoJogador;
    public GameObject prefabDaExplosao;

    // sistema de ondas de inimigos
    public float _contagemRegressiva;
 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        _contagemRegressiva = 50f;

        // trava o mouse ao iniciar o jogo
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ContagemRegressiva();
        MenuPausa();
    }

    public void GameOver()
    {
        gameOverAtivado = true;

        // intancia a explosão onde o jogador estava quando morreu
        Instantiate(prefabDaExplosao, objectoJogador.position, Quaternion.identity);

        // desbloqueia o mouse
        Cursor.lockState = CursorLockMode.None;

        // ativa o painel de game over
        _painelGameOver.SetActive(true);

        // desativa o texto dos pontos no topo da tela
        _textoDePontuacaoDoHUD.SetActive(false);

        // desativa a imagem do HUD de vidas 
        _imagemNavesHUD.SetActive(false);

        // mostra os pontos feitos na partida
        _pontuacaoFinal.text = "Score " + _inimigosDerrotados;

        // mostra a melhor pontuação em comparação com a atual 
        _recorde.text = "high score " + ConsultarMelhorPontuacao(_bestScore).ToString();

        DefinirMelhorPontuacao(_bestScore, _inimigosDerrotados); 

    }

    // atualiza o HUD de vida com a quantidade de vida atual
    public void DisplayDeVidas(int vidasDoJogador)
    {
        if (vidasDoJogador >= 0)
        {
            // o metodo recebe um numero de 0 a 3 e atualiza com a imagem correspondente
            _spriteAtual.sprite = _spritesDeVidaHUD[vidasDoJogador];

            if (vidasDoJogador == 2)
            {
                // ativa animação de fumaça na nave do jogador
                _danoMenor.SetActive(true);
            }
            else if (vidasDoJogador == 1)
            {
                // troca a animação para aparentar que o dano ficou mais grave
                _danoMenor.SetActive(false);
                _danoMaior.SetActive(true);
            }
            else if (vidasDoJogador == 0)
            {
                // Desativa a animação após o jogador ser destruido
                _danoMaior.SetActive(false);
            }
        }
    }

    // HUD de pontos por nova destruida
    public void Pontuacao()
    {
        // Sistema que verifica quantos inimigos já foram derrotados
        // e incrementa o aumento quanto maior a quantidade de inimigos derrotados mais pontos

        switch(_inimigosDerrotados)
        {
            case >= 1000:
                _inimigosDerrotados += 10;
                break;

            case >= 500:
                _inimigosDerrotados += 5;
                break;

            case >= 400:
                _inimigosDerrotados += 4;
                break;

            case >= 300:
                _inimigosDerrotados += 3;
                break;

            case >= 200:
                _inimigosDerrotados += 2;
                break;

            default:
                _inimigosDerrotados++;
                break;
        }
        // atualiza o UI de pontos na tela
        _textoPontosDoJogador.text = _inimigosDerrotados.ToString();
    }

    // recarrega a cena
    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase 1");
    }

    // fecha o jogo
    public void SairDoJogo()
    {
        Application.Quit();
    }

    // volta para o Menu
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // acessa o PlayerPrefs e defini a melhor pontuacao
    private void DefinirMelhorPontuacao(string melhorPontuacao, int numero)
    {
        // verifica se a pontuação atual é maior que o recorde e salva
        if(_inimigosDerrotados >= ConsultarMelhorPontuacao(_bestScore))
        {
            PlayerPrefs.SetInt(_bestScore, _inimigosDerrotados);
        }
    }

    // acessa o PlayerPrefs e consulta a melhor pontuação
    private int ConsultarMelhorPontuacao(string melhorPontuacao)
    {
        return PlayerPrefs.GetInt(melhorPontuacao);
    }

    // Sistema de ondas de inimigos
    private void AumentarDificuldade()
    {
        if(gameOverAtivado == false)
        {
            // Diminui a frequencia de surgimento de novos inimigos
            if (FindObjectOfType<GerenciadorDeSurgimentoDeInimigos>().frequenciaDeSurgimento > 2)
            {
                FindObjectOfType<GerenciadorDeSurgimentoDeInimigos>().frequenciaDeSurgimento--;
            }

            // aumenta a velocidade dos inimigos
            FindObjectOfType<Inimigo>()._velocidadeDoInimigo++;

            Debug.Log("Dificuldade Aumentada");
        }
    }

    private void ContagemRegressiva()
    {
        _contagemRegressiva -= Time.deltaTime;

        if(_contagemRegressiva <= 0)
        {
            // resetando o valor da variavel
            _contagemRegressiva = 50f;

            AumentarDificuldade();
        }
    }

    // Pausa e despausa o jogo
    private void MenuPausa()
    {
        if (gameOverAtivado == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_jogoEstaPausado == false)
                {
                    // muda valor da variavel de verificação 
                    _jogoEstaPausado = true;

                    // pausa o jogo
                    Time.timeScale = 0;

                    // ativa o painel de pausa
                    _painelDePausa.SetActive(true);

                    // libera o mouse
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    // muda o valor da varivel de verificação 
                    _jogoEstaPausado = false;

                    // despausa o jogo 
                    Time.timeScale = 1;

                    // desativa o painel de pausa
                    _painelDePausa.SetActive(false);

                    // captura o mouse novamente
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}
