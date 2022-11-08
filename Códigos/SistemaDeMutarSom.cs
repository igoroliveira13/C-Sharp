  // === Sitema de mutar ===

    [SerializeField]
    private bool _mutarJogoAtivado;

    // posição 0 volume ligado | posiçõa 1 volume desligado
    [SerializeField]
    private GameObject[] _botaoMutar;

     // Ativa ou desativa os efeitos sonoros 
    public void EfeitosSonoros()
    {
        if(_mutarJogoAtivado == false)
        {
            // desativa o botão de som ligado e ativa o botão som desligado
            _botaoMutar[0].SetActive(false);
            _botaoMutar[1].SetActive(true);

            // mudando o valor da variavel para verdadeiro
            _mutarJogoAtivado = true;

            _somDaMoeda.volume = 0;
            _musicaDoJogo.volume = 0;
            _musicaDeGameOver.volume = 0;
        }
        else
        {
            // desativa o botão de som desligado e ativa o botão de som ligado
            _botaoMutar[1].SetActive(false);
            _botaoMutar[0].SetActive(true);

            // mudando o valor da variavel para falso
            _mutarJogoAtivado = false;

            _somDaMoeda.volume = 0.5f;
            _musicaDoJogo.volume = 0.5f;
            _musicaDeGameOver.volume = 0.5f;

        }
        
    }