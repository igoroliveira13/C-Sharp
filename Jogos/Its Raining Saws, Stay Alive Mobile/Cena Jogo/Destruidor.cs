using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    // Resumo - Destroi as moedas e as serras que saem da tela do jogo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Serra"))
        {
            GameManager.Instance.SerrasDesviadas();
        }

        Destroy(collision.gameObject);
    }
}
