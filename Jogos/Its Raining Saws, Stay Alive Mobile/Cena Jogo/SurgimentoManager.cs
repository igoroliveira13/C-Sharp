using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgimentoManager : MonoBehaviour
{
    // === Prefabs ===

    public      GameObject[]        prefabs;

    // ============================================

    // === variavies de tempo ===

    private     float     _tempoSerra;
    private     float     _tempoMoeda;

    // ============================================

    // Start is called before the first frame update
    void Start()
    {
        // Atribuindo valor as variaveis
        _tempoSerra     =    2;
        _tempoMoeda     =    4;

        Invoke("SurgimentoSerras", _tempoSerra);
        Invoke("SurgimentoMoeda", _tempoMoeda);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SurgimentoSerras()
    {
        int _posicaoRandomicaX = UnityEngine.Random.Range(-9, 10);

        if (GameManager.Instance.autorizarSurgimento)
        {
            Instantiate(prefabs[0], new Vector3(_posicaoRandomicaX, 10, 1), Quaternion.identity);
        }

        Invoke("SurgimentoSerras", GameManager.Instance._tempoSerra);
    }

    private void SurgimentoMoeda()
    {
        int _posicaoRandomicaX = UnityEngine.Random.Range(-9, 9);

        if (GameManager.Instance.autorizarSurgimento)
        {
            Instantiate(prefabs[1], new Vector3(_posicaoRandomicaX, 10, 1), Quaternion.identity);
        }

        Invoke("SurgimentoMoeda", GameManager.Instance._tempoMoeda);
    }

}
