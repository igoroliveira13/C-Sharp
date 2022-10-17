using UnityEngine;

public class DestruirAposUmTempo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirEsteGameObject", 5);
    }

    // destroi após 5 segundos
    void DestruirEsteGameObject()
    {
        Destroy(this.gameObject);
    }
}
