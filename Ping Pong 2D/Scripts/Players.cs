using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    // Player
    public float velocidade;
    public float minimoY;
    public float maximoY;

    // variaveis pontuação
    public int pontuacaoMaxima;
    public int pontuacaoAtual;


    // texto UI pontuação
    public TMPro.TMP_Text contadorDePontos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer1();
    }

    public void MovimentoPlayer1()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, minimoY, maximoY));
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }

    // identifica a colisão para contar os pontos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bola"))
        {
            pontuacaoAtual += 1;

            // monstrando pontos na UI
            contadorDePontos.text = "Pontuação - " + pontuacaoAtual;

            AumentaVelocidadeBola();
        }
    }

    // aumentado a velocidade da bola
    void AumentaVelocidadeBola()
    {
        FindObjectOfType<Bola>().velocidadeBola += 10;
    }
}
