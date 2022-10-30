using System.Collections;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // vidas do jogador 
    public int quantidadeDeVidasDoJogador = 3;

    // animator do jogador
    [SerializeField]
    private Animator _animacoesDoJogador;

    // Velocidade do jogador
    [SerializeField]
    private float _velocidadeDoJogador;
    [SerializeField]
    private float _powerUpAumentoVelocidade;

    // Ridibory 
    public Rigidbody2D corpoRigido;

    // game object do propulsor da nave 
    [SerializeField]
    private GameObject _imagemDoPropulsorDaNave;

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
    public AudioSource somDoTiroLaser;

    // Variaveis de verificação de Power Ups
    bool _tiroTriploLiberado = false;
    bool _aumentarVelocidadeDoJogador = false;
    [SerializeField]
    bool _escudosAtivados = false;
    public AudioSource somColetaPowerUPs;

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
        VirarParaEsquerda();
        VirarParaDireita();
    }


    private void MovimentoDoJogador()
    {
        if (GameManager.instance.gameOverAtivado == false)
        {

            corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _velocidadeDoJogador;

            if (_aumentarVelocidadeDoJogador == true)
            {
                corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _powerUpAumentoVelocidade;

            }
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
        if (GameManager.instance.gameOverAtivado == false)
        {


            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > tempoEntreDisparos)
            {
                tempoEntreDisparos = Time.time + cadenciaDeTiro;

                if (_tiroTriploLiberado == true)
                {
                    // Trio Triplo
                    Instantiate(prefabTiroTriplo, origemDoDisparoDoLaser.position, Quaternion.identity);

                    // tocar som do tiro laser
                    somDoTiroLaser.Play();
                }
                else
                {
                    // instancia o laser 
                    Instantiate(prefabTiroSimples, origemDoDisparoDoLaser.position, Quaternion.identity);

                    // tocar som do tiro laser
                    somDoTiroLaser.Play();
                }
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

            if(quantidadeDeVidasDoJogador <= 0)
            {
                GameManager.instance.GameOver();

                Destroy(this.gameObject);
            }
        }

    }

    // verifica qual o power up coletado e ativa
    public void AtivarPowerUp(int numeroDopowerUpParaAtivar)
    {
        // tocar o som de coleta dos Power Ups
        somColetaPowerUPs.Play();

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
        yield return new WaitForSeconds(15.0f);

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

    private void VirarParaDireita()
    {
        // Verifica se a nava esta indo para direita e roda a animação de virar
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _animacoesDoJogador.SetBool("Virando Direita", true);
        }
        else
        {
            _animacoesDoJogador.SetBool("Virando Direita", false);
        }
    }

    private void VirarParaEsquerda()
    {
        // Verifica se a nava esta indo para esquerda e roda a animação de virar
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _animacoesDoJogador.SetBool("Virando Esquerda", true);
        }
        else
        {
            _animacoesDoJogador.SetBool("Virando Esquerda", false);
        }
    }
}
