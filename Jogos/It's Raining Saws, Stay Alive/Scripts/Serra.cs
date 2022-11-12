using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    private int _velocidadeAtual;

    // Start is called before the first frame update
    void Start()
    {
        _velocidadeAtual = FindObjectOfType<GerenciadorDeSurgimento>().testeVelocidade;
    }

    // Update is called once per frame
    void Update()
    {
        SerraCaindo(_velocidadeAtual);
    }

    // move a serra no eixo Y de cima para baixo da tela
    private void SerraCaindo(int velocidadeDaSerra)
    {
        transform.position += Vector3.down * _velocidadeAtual * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }

}
