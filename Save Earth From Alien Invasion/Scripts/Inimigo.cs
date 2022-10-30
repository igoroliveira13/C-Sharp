using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    Animator _animacoesDoInimigo;

    // velocidade do inimigo
    public float _velocidadeDoInimigo;

    // array que armazena os locais onde o inimigo ira surgir
    [SerializeField]
    Transform[] _pontosDeRessurgimento;

    // Armazena o ponto randomico de ressurgimento
    int _pontoRandomizado;

    // som nave inimiga explodindo
    public AudioSource somNaveInimigaExplodindo;

    // Array dos propulsores
    [SerializeField]
    private GameObject[] _propulsoresDoInimigo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovimentoDoInimigo();
        DeVoltaAoTopo();
    }

    private void MovimentoDoInimigo()
    {
        transform.position += Vector3.down * _velocidadeDoInimigo * Time.deltaTime;
    }

    private void DeVoltaAoTopo()
    {
        // Reseta a posição do inimigo quando o mesmo sai de cena

        if (transform.position.y < -8.0f)
        {
            // escolhe local de ressurgimento no eixo X
            _pontoRandomizado = Random.Range(-7, 7);

            // Reseta o inimigo para o novo local
            transform.position = new Vector3(_pontoRandomizado, 8, 0);

        }
    }

    // verifica colisao e adiciona pontos ao jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // faz a nave inimiga parar de se mover
            _velocidadeDoInimigo = 0;

            // desativa o box collider do inimigo
            BoxCollider2D caixaDeColisao = this.GetComponent<BoxCollider2D>();
            caixaDeColisao.enabled = false;

            // Reduz uma vida do jogador
            collision.GetComponent<Jogador>().MachucarJogador();

            // desativa os propulsores ao destruir a nave
            _propulsoresDoInimigo[0].SetActive(false);
            _propulsoresDoInimigo[1].SetActive(false);

            // toca o som da nave inimiga explodindo
            somNaveInimigaExplodindo.Play();

            // animação da nove inimiga explodindo
            _animacoesDoInimigo.SetBool("Inimigo Explodindo", true);

            // Destruir a nave inimiga se colidir com o jogador
            Invoke("DestruirEsteGameObject", 5);
        }

        if(collision.tag == "Laser")
        {
            // faz a nave inimiga parar de se mover
            _velocidadeDoInimigo = 0;

            TiroLaser tirolaser = collision.GetComponent<TiroLaser>();

            if (tirolaser != null)
            {
                // desativa o box collider do inimigo
                BoxCollider2D caixaDeColisao = this.GetComponent<BoxCollider2D>();
                caixaDeColisao.enabled = false;

                // destroi o laser que atingiu o nimigo
                Destroy(collision.gameObject);

                // toca o som da nave inimiga explodindo
                somNaveInimigaExplodindo.Play();

                // desativa os propulsores do inimigo
                _propulsoresDoInimigo[0].SetActive(false);
                _propulsoresDoInimigo[1].SetActive(false);

                // Roda a animação do inimigo explodindo
                _animacoesDoInimigo.SetBool("Inimigo Explodindo", true);

                // acessa o GameManager e atualiza a pontuação do jogador
                GameManager.instance.Pontuacao();

                // e destroi o inimigo também
                Invoke("DestruirEsteGameObject", 5f);
            }
        }
    }

    private void DestruirEsteGameObject()
    {
        Destroy(this.gameObject);
    }

}
