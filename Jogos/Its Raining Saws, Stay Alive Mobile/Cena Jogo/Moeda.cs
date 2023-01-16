using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    // comportamento da Moeda 

    private     float   _velocidade;

    // Start is called before the first frame update
    void Start()
    { 
        _velocidade = GameManager.Instance.velocidadeDaMoeda;
    }

    // Update is called once per frame
    void Update()
    {
        MoedaCaindo();
    }

    private void MoedaCaindo()
    {
        transform.Translate(Vector2.down * _velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.MoedaColetada();

            Destroy(this.gameObject);
        }
    }
}
