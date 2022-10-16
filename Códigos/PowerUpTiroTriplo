using UnityEngine;

public class TiroTriplo : MonoBehaviour
{
    float _VelocidadeDoPowerUp = 0.1f;

    // Ativa o tiro triplo no script do jogador

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Jogador>().tiroTriploLiberado = true;

            DestroiEstePowerUp();
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.down * _VelocidadeDoPowerUp;
    }

    void DestroiEstePowerUp()
    {
        Destroy(this.gameObject);
    }
}
