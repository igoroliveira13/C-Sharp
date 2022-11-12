using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody2D _corpoRigido;

    [SerializeField]
    private float _velocidadeDoJogador;

    [SerializeField]
    private Animator _animacoesDoJogador;

    // Start is called before the first frame update
    void Start()
    {
        _corpoRigido = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OlharParaOsLados();
    }

    private void FixedUpdate()
    {
        MovimentoDoJogador();
    }

    // recebe comandos do teclado e movimenta o jogador
    private void MovimentoDoJogador()
    {
        _corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal") * _velocidadeDoJogador, 0);

        // verifica se o jogador esta pressionando alguma tecla de movimento
        if (Input.GetAxis("Horizontal") != 0)
        {
            // roda a animação do personagem correndo
            //_animacoesDoJogador.SetBool("correndo", true);
            _animacoesDoJogador.Play("correndo");
        }
        else
        {
            // desativa a animação correndo
            //_animacoesDoJogador.SetBool("correndo", false); 
            _animacoesDoJogador.Play("idle");
        }
    }

    // verifica a direção que o jogador esta indo e muda a sprite
    private void OlharParaOsLados()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // vira o sprite do jogador para direita
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // vira a sprite para esquerda
        {
            // vira o sprite do jogador para esquerda
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
