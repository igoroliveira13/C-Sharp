using UnityEngine;

public class Chave : MonoBehaviour
{
    public GameObject chaveUI;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Jogador>().tenhoUmaChave = true;

            DestruirChave();

            // ativa a imagem da chave no canvas
            FindObjectOfType<GameManager>().MostrarChaveNoUI();
        }
        
    }

    void DestruirChave()
    {
        Destroy(this.gameObject);

        FindObjectOfType<EfeitosSonoros>().TocarSomColetaChave();
    }
}
