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
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOverAtivado = true;

        // ativa o painel de game over
        _painelGameOver.SetActive(true);

        // desativa o texto dos pontos no topo da tela
        _textoDePontuacaoDoHUD.SetActive(false);

        // desativa a imagem do HUD de vidas 
        _imagemNavesHUD.SetActive(false);

        // mostra os pontos feitos na partida
        _pontuacaoFinal.text = "Score " + _inimigosDerrotados;

        // mostra a melhor pontuação em comparação com a atual 
        _recorde.text = "best score " + ConsultarMelhorPontuacao(_bestScore).ToString();

        DefinirMelhorPontuacao(_bestScore, _inimigosDerrotados); 

    }

    // atualiza o HUD de vida com a quantidade de vida atual
    public void DisplayDeVidas(int vidasDoJogador)
    {
        // o metodo recebe um numero de 0 a 3 e atualiza com a imagem correspondente
        _spriteAtual.sprite = _spritesDeVidaHUD[vidasDoJogador];
    }

    // HUD de pontos por nova destruida
    public void Pontuacao()
    {
        // incrementa em 1 o score do jogador
        _inimigosDerrotados++;

        // atualiza o UI de pontos na tela
        _textoPontosDoJogador.text = _inimigosDerrotados.ToString();
    }

    // recarrega a cena
    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void SairDoJogo()
    {
        Application.Quit();
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
}
