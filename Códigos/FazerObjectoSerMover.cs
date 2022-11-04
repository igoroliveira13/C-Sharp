using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SerraGameOver : MonoBehaviour
{
    // faz um gameobject ficar se movendo entre pontos em loop na tela

    // armazena a posição dos GameObject vazio 
    [SerializeField]
    private Transform[] _pontosMoverSerra;

    private Vector3 _pontoDeDestino;

    [SerializeField]
    private int _velocidadeDaSerra;

    // Start is called before the first frame update
    void Start()
    {
        // inicia a serra no primeiro ponto 
        transform.position = _pontosMoverSerra[0].position;

        // iniciando o ponto de destino com a primeira localização
        _pontoDeDestino = _pontosMoverSerra[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoverSerraTelaGameOver();
    }

    private void MoverSerraTelaGameOver()
    {
        if(transform.position == _pontosMoverSerra[0].position)
        {
            _pontoDeDestino = _pontosMoverSerra[1].position;
        }

        if(transform.position == _pontosMoverSerra[1].position)
        {
            _pontoDeDestino = _pontosMoverSerra[2].position;
        }

        if(transform.position == _pontosMoverSerra[2].position)
        {
            _pontoDeDestino = _pontosMoverSerra[3].position;
        }

        if(transform.position == _pontosMoverSerra[3].position)
        {
            _pontoDeDestino = _pontosMoverSerra[0].position;
        }

        // faz a serra se mover em diração ao pontoDeDestino
        transform.position = Vector2.MoveTowards(transform.position, _pontoDeDestino, _velocidadeDaSerra * Time.deltaTime);
    }
        
}
