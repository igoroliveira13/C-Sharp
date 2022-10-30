using UnityEngine;

public class TiroLaser : MonoBehaviour
{
    // velocidade do laser
    public float velocidadeDoTiroLaser;

    // Faz o GameObject se mover para frente na Scene
    void IrParaFrente()
    {
        transform.position += new Vector3(0, velocidadeDoTiroLaser, 0);

        DestruirQuandoSairDeCena();
    }

    void DestruirQuandoSairDeCena()
    {
        if(transform.position.y >= 6f)
        {
            Destroy(this.gameObject);
        }
    }

    // FixedUpdate é chamado a cada 0.02 segundos
    private void FixedUpdate()
    {
        IrParaFrente();
    }
}
