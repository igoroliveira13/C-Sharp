using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    // irá destruir os objetos que saem de cena 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(collision.gameObject);

    }
}
