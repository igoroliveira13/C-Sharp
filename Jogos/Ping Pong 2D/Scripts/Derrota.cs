using UnityEngine;

public class Derrota : MonoBehaviour
{
    // UI de game over
    public TMPro.TMP_Text gameOver;

    public GameObject textoGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bola"))
        {
            FindObjectOfType<GameManager>().chances--;
        }
    }
}
