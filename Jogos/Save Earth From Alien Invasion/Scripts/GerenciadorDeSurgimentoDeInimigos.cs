using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSurgimentoDeInimigos : MonoBehaviour
{
    // Armazena a nave inimiga
    [SerializeField]
    GameObject _naveInimiga;

    // array armazena os pontos de surgimento iniciais
    [SerializeField]
    Transform[] _pontosDeSurgimento;

    // De quanto em quanto tempo novos inimigos s�o incluidos
    private int _segundos = 7;

    // armazenara um numero randomico para o ponto de surgimento
    private int _numeroRandomico;


    // Start is called before the first frame update
    void Start()
    {
        IncluirMaisInimigos();
    }

    private void IncluirMaisInimigos()
    {
        if (FindObjectOfType<GameManager>().gameOverAtivado == false)
        {
            // gera um numero randomico para a variavel
            _numeroRandomico = Random.Range(0, 3);

            // instacia a nave inimiga no ponto informado
            Instantiate(_naveInimiga, _pontosDeSurgimento[_numeroRandomico].position, Quaternion.identity);

            // Metado ap�s ser iniciado chama a si mesma a cada X segundos
            Invoke("IncluirMaisInimigos", _segundos);
        }

    }
}

// Este c�digo faz com que uma nova nave inimiga apare�a em tela de tempos em tempos