using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    GameManager gameManager;

    public bool _indoParaDireita;

    private float _velocidade;
    

    // Start is called before the first frame update
    void Start()
    {
        _velocidade = GameManager.Instance.velocidadeDoJogador;

    }

    // Update is called once per frame
    void Update()
    {
        MovimentoDoJogador();
   
    }

    private void MovimentoDoJogador()
    {
        if(_indoParaDireita)
        {
            // movimenta o personagem para a direita
            transform.Translate(Vector2.right * _velocidade * Time.deltaTime);

            // faz o personagem olhar para direita
            transform.localScale = new Vector3(1, 1, 1);

            // verifica se chegou no limite da tela e muda a direção
            if (transform.position.x >= 9f)
            {
                _indoParaDireita = !_indoParaDireita;
            }
        }
        else
        {
            // movimenta o personagem para a esquerda
            transform.Translate(-Vector2.right * _velocidade * Time.deltaTime);

            // faz o personagem olhar para direita
            transform.localScale = new Vector3(-1, 1, 1);

            // verifica se chegou no limite da tela e muda a direção
            if (transform.position.x <= -9f)
            {
                _indoParaDireita = !_indoParaDireita;
            }
        }

        // Quando clica com mouse ou toca na tela com o dedo muda o valor da variavel
        if (Input.GetMouseButtonDown(0))
        {
            _indoParaDireita = !_indoParaDireita;
        }

        _velocidade = GameManager.Instance.velocidadeDoJogador;
    }

}
