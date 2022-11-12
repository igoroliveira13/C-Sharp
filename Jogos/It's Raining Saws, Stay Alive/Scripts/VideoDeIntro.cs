using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoDeIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CarregarMenu", 12);
    }

    // Carrega o menu
    public void CarregarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
