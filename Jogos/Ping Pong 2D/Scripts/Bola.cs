using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    // variaveis da bola
    public float velocidadeBola;
    public Rigidbody2D rigidBo;

    // audio bola
    public AudioSource somDaBola;

    // Start is called before the first frame update
    void Start()
    {
        rigidBo = GetComponent<Rigidbody2D>();

        // aplica força para direita
        rigidBo.velocity = new Vector2(velocidadeBola, velocidadeBola) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Derrota"))
        {
            if (FindObjectOfType<GameManager>().chances > 0)
            {
                // faz a bola reaparecer no centro da tela
                transform.position = Vector2.zero;

                // no ressurgimento a bola vai para direita
                rigidBo.velocity = new Vector2(velocidadeBola, velocidadeBola) * Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // toca o som da bola sempre que há uma colisão
        somDaBola.Play();
    }
}
