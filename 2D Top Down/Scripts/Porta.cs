using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public string irParaCena;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FindObjectOfType<Jogador>().tenhoUmaChave == true)
            {
                // desativa a imagem da chave no canvas
                FindObjectOfType<GameManager>().EsconderChaveUI();

                // carrega outra fase
                SceneManager.LoadScene(irParaCena);
            }
        }
    }
}
