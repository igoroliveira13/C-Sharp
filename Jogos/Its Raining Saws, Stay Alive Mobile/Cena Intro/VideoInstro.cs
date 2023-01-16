using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoInstro : MonoBehaviour
{
    private      float       _tempo;

    // Start is called before the first frame update
    void Start()
    {
        _tempo = 11f;
    }

    // Update is called once per frame
    void Update()
    {
        CarregarMenu();
    }

    private void CarregarMenu()
    {
        _tempo -= Time.deltaTime;

        if(_tempo < 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
