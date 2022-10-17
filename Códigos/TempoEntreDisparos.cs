    [Header("Sistema de Tiro")]
    // Prefab do laser
    public GameObject tiroLaser;

    // ponto onde o laser será instanciado
    public Transform pontoOrigemLaser;
 
    // tempo entre disparos 
    public float cadenciaDeTiro;
    float tempoEntreDisparos = 0.0f;

      void SistemaDeTiro()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && Time.time > tempoEntreDisparos)
        {
            tempoEntreDisparos = Time.time + cadenciaDeTiro;

            // instancia o laser 
            Instantiate(tiroLaser, pontoOrigemLaser.position, Quaternion.identity);
        }
    }