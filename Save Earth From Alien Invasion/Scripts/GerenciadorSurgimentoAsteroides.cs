using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gerencia o local e a frequencia de surgimento de asteroides

public class GerenciadorSurgimentoAsteroides : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabsDosAsteroide;

    // rondomiza um local para o surgimento do asteroide
    private int _numeroRandomico;

    // randomiza o astoreide que será instanciado
    private int _asteroideRandomico;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IncluirAsteroideEmCena", 20);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncluirAsteroideEmCena()
    {
        // definindo um numero aleatorio para surgir
        _numeroRandomico = Random.Range(-7, 7);

        // escolhendo um asteroide dentro os 4 disponiveis
        _asteroideRandomico = Random.Range(0, 4);

        // instacia o asteroide
        Instantiate(_prefabsDosAsteroide[_asteroideRandomico], new Vector3(_numeroRandomico,7,0), Quaternion.identity);

        // metodo chama a si mesmo de tempos em tempos
        Invoke("IncluirAsteroideEmCena", 20);
    }
}
