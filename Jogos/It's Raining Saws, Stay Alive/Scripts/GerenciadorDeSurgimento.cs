using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSurgimento : MonoBehaviour
{
    // gerencia o surgimento de moedas e de serras 

    // === Prefabs ===

    [SerializeField]
    private GameObject _prefabDaMoeda;

    [SerializeField]
    private GameObject _prefabDaSerra;

    // === Sistema de dificuldade ===

    public int testeVelocidade;
    private float _contagemRegressiva;
    private float _tempoPadrao;

   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ColocarMoedaEmCena", 4);
        Invoke("ColocarSerraEmCena", 2);

        testeVelocidade = 7;

        _tempoPadrao = 180;
        _contagemRegressiva = _tempoPadrao;
    }

    // Update is called once per frame
    void Update()
    {
        AumentarVelocidadeDaSerra();
    }

    // Gera um local randomico e instancia a moeda em cena
    private void ColocarMoedaEmCena()
    {
        // gera um numero randomico para o eixo X
        int numeroRandomico = Random.Range(-10, 10);

        // instancia a moeda em tela
        Instantiate(_prefabDaMoeda, new Vector3(numeroRandomico, 10, 0), Quaternion.identity);

        // Metodo chama a si mesmo 
        Invoke("ColocarMoedaEmCena", 4);
    }

    // Gera um local randomico e intancia a serra em cena
    private void ColocarSerraEmCena()
    {
        // gera um numero randomico para o eixo X
        int numeroRandomico = Random.Range(-10, 10);

        // Instancia a serra em tela
        Instantiate(_prefabDaSerra, new Vector3(numeroRandomico, 10, 0), Quaternion.identity);

        // Metodo chama a si mesmo
        Invoke("ColocarSerraEmCena", 1);
    }

    // a cada x minutos as serras ficam mais rapidas
    private void AumentarVelocidadeDaSerra()
    {
        _contagemRegressiva -= Time.deltaTime;

        if(_contagemRegressiva <= 0)
        {
            testeVelocidade++;

            _contagemRegressiva = _tempoPadrao;

            Debug.Log("Velocidade aumentada");
        }
    }
}