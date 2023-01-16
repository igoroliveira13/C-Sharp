using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallpaper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 escala = GetComponentInChildren<Transform>().transform.localScale;

        float largura = sprite.bounds.size.x;
        float altura = sprite.bounds.size.y;

        float alturaCamera = Camera.main.orthographicSize * 2.0f;
        float larguraDaTela = alturaCamera / Screen.height * Screen.width;

        escala.x = larguraDaTela / largura;
        escala.y = alturaCamera / altura;

        transform.localScale = escala;
    }
}
