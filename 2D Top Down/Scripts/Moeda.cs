using UnityEngine;

public class Moeda : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // adicinando uma moeda 
            collision.GetComponent<Jogador>().quantidadeDeMoedas += 1;

            // atualiza o UI contador de moedas
            collision.GetComponent<Jogador>().contadorDeMoedas.text = "X " + collision.GetComponent<Jogador>().quantidadeDeMoedas;

            DestruirMoeda();
        }
    }

    void DestruirMoeda()
    {
        FindObjectOfType<EfeitosSonoros>().TocarSomColetaMoeda();

        Destroy(this.gameObject);
    }
}
