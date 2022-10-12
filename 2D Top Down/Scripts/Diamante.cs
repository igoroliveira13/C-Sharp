using UnityEngine;

public class Diamante : MonoBehaviour
{
    public GameObject diamante;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(diamante, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
