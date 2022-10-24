using System.Collections;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // vidas do jogador 
    public int quantidadeDeVidasDoJogador = 3;

    // animator do jogador
    [SerializeField]
    Animator _animacoesDoJogador;

    // Velocidade do jogador
    [SerializeField]
    float _velocidadeDoJogador;
    [SerializeField]
    float _powerUpAumentoVelocidade;

    // Ridibory 
    public Rigidbody2D corpoRigido;

    // skin dos escudos
    [SerializeField]
    GameObject _skinDeEscudos;

    // limitadores de movimento 
    float limiteMaximoY = -1.29f;
    float limiteMinimoY = -4.44f;
    float limiteMaximoX = 8.2f;
    float limiteMinimoX = -8.28f;


    [Header("Sistema de Tiro")]
    // Prefab do laser
    public GameObject prefabTiroSimples;
    public GameObject prefabTiroTriplo;

    // Variaveis de verificação de Power Ups
    bool _tiroTriploLiberado = false;
    bool _aumentarVelocidadeDoJogador = false;
    [SerializeField]
    bool _escudosAtivados = false;

    // ponto onde o laser será instanciado
    public Transform origemDoDisparoDoLaser;

    // tempo entre disparos 
    public float cadenciaDeTiro;
    float tempoEntreDisparos = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody2D>();

        FindObjectOfType<GameManager>().DisplayDeVidas(quantidadeDeVidasDoJogador);
    }

    // Update is called once per frame
    void Update()
    {
        LimitadorDeMovimento();
        SistemaDeTiro();
    }

    // FixedUpdate é chamado a cada 0.02 segundos
    private void FixedUpdate()
    {
        MovimentoDoJogador();
    }


    private void MovimentoDoJogador()
    {
        corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _velocidadeDoJogador;

        if (_aumentarVelocidadeDoJogador == true)
        {
            corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _powerUpAumentoVelocidade;

        }
    }

    private void LimitadorDeMovimento()
    {
        // limitador topo
        if (transform.position.y > limiteMaximoY)
        {
            transform.position = new Vector3(transform.position.x, limiteMaximoY, transform.position.z);
        }

        // limitador inferior
        if (transform.position.y < limiteMinimoY)
        {
            transform.position = new Vector3(transform.position.x, limiteMinimoY, transform.position.z);
        }

        // limitador lateral esquerda
        if (transform.position.x < limiteMinimoX)
        {
            transform.position = new Vector3(limiteMinimoX, transform.position.y, transform.position.z);
        }

        // limitador lateral direita
        if (transform.position.x > limiteMaximoX)
        {
            transform.position = new Vector3(limiteMaximoX, transform.position.y, transform.position.z);
        }
    }

    private void SistemaDeTiro()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > tempoEntreDisparos)
        {
            tempoEntreDisparos = Time.time + cadenciaDeTiro;

            if (_tiroTriploLiberado == true)
            {
                // Trio Triplo
                Instantiate(prefabTiroTriplo, origemDoDisparoDoLaser.position, Quaternion.identity);
            }
            else
            {
                // instancia o laser 
                Instantiate(prefabTiroSimples, origemDoDisparoDoLaser.position, Quaternion.identity);
            }
        }
    }

    // reduz vida do jogador
    public void MachucarJogador()
    {
        // enquato o escudo estiver ativado o jogador não sofre dano
        if (_escudosAtivados == true)
        {
            return;
        }
        else
        {
            // reduz uma vida do jogador
            quantidadeDeVidasDoJogador--;

            // atualiza o numero de vidas atuais no HUD
            GameManager.instance.DisplayDeVidas(quantidadeDeVidasDoJogador);

            if (quantidadeDeVidasDoJogador <= 0)
            {
                // ativa o painel de game over
                FindObjectOfType<GameManager>().GameOver();

                // aniamação do jogador explodindo
                _animacoesDoJogador.SetBool("Jogador Explodindo", true);

                // destruir após rodar animação de explosão
                Invoke("FimDeJogo", 5);
            }
        }

    }

    // verifica qual o power up coletado e ativa
    public void AtivarPowerUp(int numeroDopowerUpParaAtivar)
    {
        if (numeroDopowerUpParaAtivar == 1)
        {
            _tiroTriploLiberado = true;
            Debug.Log("Tiro Triplo ativado");
        }

        else if (numeroDopowerUpParaAtivar == 2)
        {
            // aumentar a velocidade
            _aumentarVelocidadeDoJogador = true;

            Debug.Log("Aumento de velocidade ativado");
        }

        else if (numeroDopowerUpParaAtivar == 3)
        {
            // ativa os escudos 
            _skinDeEscudos.SetActive(true);

            // verificação escudos ativados 
            _escudosAtivados = true;

            Debug.Log("Escudos Ativados");
        }

        StartCoroutine(DesativarPowerUp(numeroDopowerUpParaAtivar));
    }

    // desativa o power up que foi ativado após 10 segundas
    public IEnumerator DesativarPowerUp(int numeroDoPowerUpParaDesativar)
    {
        yield return new WaitForSeconds(10.0f);

        if (numeroDoPowerUpParaDesativar == 1)
        {
            _tiroTriploLiberado = false;
            Debug.Log("Tiro Triplo desativado");
        }

        else if (numeroDoPowerUpParaDesativar == 2)
        {
            // retorna a veolidade para o valor padrão
            _aumentarVelocidadeDoJogador = false;

            Debug.Log("Aumento de velocidade desativado");
        }

        else if (numeroDoPowerUpParaDesativar == 3)
        {
            // desativa os escudos
            _skinDeEscudos.SetActive(false);

            // verificação escudos ativados
            _escudosAtivados = false;

            Debug.Log("Escudos desativados");
        }
    }

    // Destroy o jogador e chama o metodo GameOver no GameManager
    private void FimDeJogo()
    {
        // destroi o jogador 
        Destroy(this.gameObject);

        // chama o metodo game over no GameManager
        GameManager.instance.GameOver();
    }
}
