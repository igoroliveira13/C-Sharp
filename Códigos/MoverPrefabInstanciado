using UnityEngine;

public class TiroLaser : MonoBehaviour
{
    // velocidade do laser
    public float velocidadeDoTiroLaser;

    // Faz o GameObject se mover para frente na Scene
    void IrParaFrente()
    {
        transform.position += new Vector3(0, velocidadeDoTiroLaser, 0);
        
        // outra forma:

        /* 
         * transform.position(Vector3.up * velocidadeDoTiroLaser);
         * */
    }

    // FixedUpdate é chamado a cada 0.02 segundos
    private void FixedUpdate()
    {
        IrParaFrente();
    }
}
