using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSurgimento : MonoBehaviour
{
    // array que armazena os pontos de surgimento
    [SerializeField]
    Transform[] _arrayPontosDeSurgimento;

    // array que armazena os Power Ups
    [SerializeField]
    GameObject[] _arrayDePowerUps;

    // Armazena o ponto de surgimento randomizado
    int _pontoDeSurgimentoRandomico;

    // Armazena o Power Up randomizado
    int _powerUpRandomico;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SurgimentoDePowerUps", 40);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SurgimentoDePowerUps()
    {
        if (FindObjectOfType<GameManager>().gameOverAtivado == false)
        {
            // Randomiza um local de surgimento
            _pontoDeSurgimentoRandomico = Random.Range(0, 16);

            // Randomiza um Power Up para ser instanciado
            _powerUpRandomico = Random.Range(0, 3);

            // Instacia o power up no ponto de surgimento
            Instantiate(_arrayDePowerUps[_powerUpRandomico], _arrayPontosDeSurgimento[_pontoDeSurgimentoRandomico].position, Quaternion.identity);

            // O metodo chama a si mesmo a cada 40 segundos
            Invoke("SurgimentoDePowerUps", 40);
        }
    }
}
