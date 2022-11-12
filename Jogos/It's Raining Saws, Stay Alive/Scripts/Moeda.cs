using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField]
    private float _velocidadeDaMoeda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoedaCaindo();
    }

    // Move a moeda do ponto de surgimento até a base da tela
    private void MoedaCaindo()
    {
        transform.position += Vector3.down * _velocidadeDaMoeda * Time.deltaTime;
    }

    // verifica se colidiu com o jogador e aumenta a quantidade de moedas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // chama o metodo que aumenta moeda e atualiza o UI
            GameManager.instance.AcrecentarMoeda();

            // Destroi este GameObject após a coleta
            Destroy(this.gameObject);
        }
    }
}
