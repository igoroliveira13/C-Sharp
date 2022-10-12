using Unity.VisualScripting;
using UnityEngine;

public class ReporVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Jogador>().AumentarVidaDoJogador();

            DestruirCoracao();
        }
    }

    void DestruirCoracao()
    {
        Destroy(this.gameObject);

        FindObjectOfType<EfeitosSonoros>().TocarSomColetaVida();
    }
}
