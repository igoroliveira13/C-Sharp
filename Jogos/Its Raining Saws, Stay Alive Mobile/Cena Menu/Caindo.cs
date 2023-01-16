using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caindo : MonoBehaviour
{
    // Faz as serras cairem no Menu 

    private     int     _velocidade;

    // Start is called before the first frame update
    void Start()
    {
        _velocidade     =   3;
    }

    // Update is called once per frame
    void Update()
    {
        Cair();
    }

    private void Cair()
    {
        transform.Translate(Vector2.down * _velocidade * Time.deltaTime);
    }
}
