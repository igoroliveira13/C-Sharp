using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidadeDeCaminhada;

    public Rigidbody2D corpoRigido;

    // Moedas
    public int quantidadeDeMoedas;
    public TMPro.TMP_Text contadorDeMoedas;

    // Vidas
    public int vidaDoJogador;
    public TMPro.TMP_Text contadorDeVidas;

    // chave para abrir as portas
    public bool tenhoUmaChave;




    private void Awake()
    {
        // buca por clones deste script e incluir no array
        Jogador[] clonesDesteScript = FindObjectsOfType<Jogador>();

        // S� pode haver um ;)
        if(clonesDesteScript.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // ao recarregar a fase ou mudar para outra fase n�o destroi o jogador
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody2D>();

        ResetarPosicao();

        // passa o valor da variavel para o UI 
        contadorDeMoedas.text = "X " + quantidadeDeMoedas;
        contadorDeVidas.text = "X " + vidaDoJogador;

        tenhoUmaChave = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ControleDeMovimento()
    {
        // movimentos personagem
        corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * velocidadeDeCaminhada;
    }

    // FixedUpdate � chamado a cada 0,02 segundos. 50 chamadas por segundo. 
    private void FixedUpdate()
    {
        ControleDeMovimento();
    }

    public void TirarVidaDoJogador()
    {
        // Tira 1 das vidas do jogador
        vidaDoJogador--;

        // atualiza o UI com a quantidade de vida atual
        contadorDeVidas.text = "X " + vidaDoJogador;
    }

    public void AumentarVidaDoJogador()
    {
        // aumenta a quantidade de vida em 1
        vidaDoJogador++;

        // atualiza o UI com a quantidade de vidas atual 
        contadorDeVidas.text = "X " + vidaDoJogador;
    }

    public void ResetarPosicao()
    {
        transform.position = Vector2.zero;
    }
}
