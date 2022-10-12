using UnityEngine;

public class DestroiAposUmTempo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroi apos 10 segundos
        Invoke("Destruir", 1.5f);
    }

    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
