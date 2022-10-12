using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    // som coleta moeda
    public AudioSource somColetaMoeda;

    // som coleta chave
    public AudioSource somColetaChave;

    // som coleta coração vida
    public AudioSource somColetaVida;

    // metodos 

    public void TocarSomColetaMoeda()
    {
        somColetaMoeda.Play();
    }

    public void  TocarSomColetaChave()
    {
        somColetaChave.Play();
    }

    public void TocarSomColetaVida()
    {
        somColetaVida.Play();
    }
}
