using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruidorMenu : MonoBehaviour
{
    // Destroi as serras que saem de tela no Menu 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
