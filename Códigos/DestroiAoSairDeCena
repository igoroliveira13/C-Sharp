using UnityEngine;

public class DestruirQuandoForaDeCena : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        DestroiAoSairDaCena();
    }

    // Verifica se o laser saiu da visão do jogador(main camera) e o destroi 
    void DestroiAoSairDaCena()
    {
        if(transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
    }
}
