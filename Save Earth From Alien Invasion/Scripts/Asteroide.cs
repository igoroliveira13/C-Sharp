using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    // velocidade de q queda
    public float _velocidadeDoAsteroide;

    [SerializeField]
    private float _velocidadeRotacaoZ;

    private int _velocidadeESentido;

    // Start is called before the first frame update
    void Start()
    {
        // randomiza a velocidade e rotacao do asteroide
        _velocidadeESentido = Random.Range(-200, 200);
        Debug.Log("Velocidade do asteroide" + _velocidadeDoAsteroide);
    }

    private void FixedUpdate()
    {
        // movimenta o asteroide para base da tela
        transform.position += Vector3.down * _velocidadeDoAsteroide;
    }

    private void Update()
    {
        RotacionarAsteroide();
        DestruirForaDeCena();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // retira uma vida do jogador 
            collision.GetComponent<Jogador>().MachucarJogador();

            // destroi o asteroide
            Destroy(this.gameObject);
        }
    }

    // faz o asteroide gierar enquanto cai
    private void RotacionarAsteroide()
    {
        _velocidadeRotacaoZ += Time.deltaTime * _velocidadeESentido;
        transform.rotation = Quaternion.Euler(0, 0, _velocidadeRotacaoZ);
    }

    // destroi o asteroide ao sair da visão da camera
    private void DestruirForaDeCena()
    {
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }
}
