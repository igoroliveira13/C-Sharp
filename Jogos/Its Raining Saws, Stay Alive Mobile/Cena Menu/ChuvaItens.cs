using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaItens : MonoBehaviour
{
    // === Prefabs ===

    public      GameObject      moeda;
    public      GameObject      serra;

    private     float           _tempoMoeda;
    private     float           _tempoSerra;

    // ======================================================

    // Start is called before the first frame update
    void Start()
    {
        // atribuindo valor as variaveis de tempo
        _tempoMoeda     =   4;
        _tempoSerra     =   2;

        //Invoke("ChuvaMoeda", _tempoMoeda);
        Invoke("ChuvaSerra", _tempoSerra);
    }

    // Faz moedas cairem na tela de menu
    private void ChuvaMoeda()
    {
        int posicaoRandomicaX = UnityEngine.Random.Range(-9, 9);

        Instantiate(moeda, new Vector3(posicaoRandomicaX, 10, 1), Quaternion.identity);

        Invoke("ChuvaMoeda", _tempoMoeda);
    }

    // Faz serras cairem na tela de menu
    private void ChuvaSerra()
    {
        int posicaoRandomicaX = UnityEngine.Random.Range(-9, 9);

        Instantiate(serra, new Vector3(posicaoRandomicaX, 10, 1), Quaternion.identity);

        Invoke("ChuvaSerra", _tempoSerra);
    }
}
