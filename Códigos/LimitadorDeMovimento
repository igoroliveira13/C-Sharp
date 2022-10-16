using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Velocidade do jogador
    public float velocidadeDoJogador;

    // Ridibory 
    public Rigidbody2D corpoRigido;

    // limitadores de movimento 
    public float limiteMaximoY;
    public float limiteMinimoY;
    public float limiteMaximoX;
    public float limiteMinimoX;

    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitadorDeMovimento();
    }

    // FixedUpdate é chamado a cada 0.02 segundos
    private void FixedUpdate()
    {
        MovimentoDoJogador();
    }

    void MovimentoDoJogador()
    {
        corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * velocidadeDoJogador;
    }

    void LimitadorDeMovimento()
    {
        // limitador topo
        if(transform.position.y > limiteMaximoY)
        {
            transform.position = new Vector3(transform.position.x, limiteMaximoY, transform.position.z);
        }

        // limitador inferior
        if(transform.position.y < limiteMinimoY)
        {
            transform.position = new Vector3(transform.position.x, limiteMinimoY, transform.position.z);
        }

        // limitador lateral esquerda
        if(transform.position.x < limiteMinimoX)
        {
            transform.position = new Vector3(limiteMinimoX, transform.position.y, transform.position.z);
        }

        // limitador lateral direita
        if(transform.position.x > limiteMaximoX)
        {
            transform.position = new Vector3(limiteMaximoX, transform.position.y, transform.position.z);
        }
    }

}
