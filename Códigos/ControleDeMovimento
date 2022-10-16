// Variavel do corpo rigido
public Rigidbody2D corpoRigido;


// Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody2D>();
    }

void ControleDeMovimento()
    {
        // movimentos personagem
        corpoRigido.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * velocidadeDeCaminhada;
    }
