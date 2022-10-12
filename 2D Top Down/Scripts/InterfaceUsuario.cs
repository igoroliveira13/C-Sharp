using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceUsuario : MonoBehaviour
{
    private void Awake()
    {
        // ira localizar clones do gameobject e atribuir ao array
        InterfaceUsuario[] clonesDoUI = FindObjectsOfType<InterfaceUsuario>();
        

        // esclui os clones 
        if(clonesDoUI.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
