using UnityEngine;

public class DestruirAposUmTempo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirEsteGameObject", 3);
    }

    void DestruirEsteGameObject()
    {
        Destroy(this.gameObject);
    }
}
