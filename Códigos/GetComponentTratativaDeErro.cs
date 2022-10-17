/* Ao trabalhar com GetComponent. Devemos garantir que o retorno não seja nulo, pois se for terá um erro que irá parar o jogo. */


private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Jogador jogador = collision.GetComponent<Jogador>();

            // este trecho garante que o retorno não seja nulo
            // pois se fosse o jogo iria para por este erro
            if (jogador != null)
            {
                jogador.tiroTriploLiberado = true;
            }

            DestroiEstePowerUp();
        }
    }