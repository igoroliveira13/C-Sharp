using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject chaveUI; 

    private void Awake()
    {
        // busca por colnes do script e os coloca no array 
        GameManager[] clonesDesteGameObject = FindObjectsOfType<GameManager>();

        // exclui as duplicatas
        if(clonesDesteGameObject.Length > 1)
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

    // ativa a imagem da chave no canvas
    public void MostrarChaveNoUI()
    {
        chaveUI.SetActive(true);
    }

    // desativa a imagem na chave no canvas
    public void EsconderChaveUI()
    {
        chaveUI.SetActive(false); 
    }
}
