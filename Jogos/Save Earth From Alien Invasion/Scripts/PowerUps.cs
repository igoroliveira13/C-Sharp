using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // verificação boleana 
    [SerializeField]
    int _powerUpDeTiroTriplo;
    [SerializeField]
    int _powerUpAumentaVelocidade;
    [SerializeField]
    int _powerUpEscudos;


    // velocidade
    [SerializeField]
    float _velocidadeDoPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoDoPowerUp();
        DestruirAoSairDecena();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Jogador jogador = collision.GetComponent<Jogador>();

            if (jogador != null)
            {
                // Ativar o tiro triplo
                if (_powerUpDeTiroTriplo == 1)
                {
                    jogador.AtivarPowerUp(_powerUpDeTiroTriplo);
                }

                // Aumenta a velocidade do jogador
                else if (_powerUpAumentaVelocidade == 2)
                {
                    jogador.AtivarPowerUp(_powerUpAumentaVelocidade);
                }

                // Ativa os escudos 
                else if (_powerUpEscudos == 3)
                {
                    jogador.AtivarPowerUp(_powerUpEscudos);
                }
            }

            DestruirEsteGameObject();
        }
    }

    private void MovimentoDoPowerUp()
    {
        transform.position += Vector3.down * _velocidadeDoPowerUp * Time.deltaTime;
    }

    private void DestruirEsteGameObject()
    {
        Destroy(this.gameObject);
    }

    private void DestruirAoSairDecena()
    {
        /* 
         * Caso o jogador não colete o Power UP, este código é execultado
         * e o power up será destruido ao sair da visão da camera Y -7
        */

        if(transform.position.y < -7.0f)
        {
            DestruirEsteGameObject();
        }
    }
}
