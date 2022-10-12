using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    public float velocidadeDoInimigo;

    // array responsavel por armazenar os pontos
    public Transform[] pontosParaCaminhar;

    // variavel que ir� alternar entre os pontos
    int destino;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
    }

    public void MovimentarInimigo()
    {
        // move o inimigo em dire��o ao ponto de patrulha
        transform.position = Vector2.MoveTowards(transform.position, pontosParaCaminhar[destino].position, velocidadeDoInimigo * Time.deltaTime);

        // verifica se o inimigo chegou no ponto e altera o mesmo para o pr�ximo local
        if(transform.position == pontosParaCaminhar[destino].position)
        {
            destino++;

            // esta condi��o garante que a variavel n�o seja maior que o tamanho do array
            if(destino == pontosParaCaminhar.Length)
            {
                destino = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // acessa o script do jogador e roda a fun�ao para tirar vida
            collision.GetComponent<Jogador>().TirarVidaDoJogador();

            // reseta a fase atual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // leva o jogador de volta ao ponto de inicio
            collision.GetComponent<Jogador>().ResetarPosicao();
        }
    }
}
