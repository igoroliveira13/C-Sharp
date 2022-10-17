/* 
Coroutines é uma fomra de fazer o código esperar por um tempo 
Este código deve estar na nave, pois se estiver no GameObject do
Power Up, após o mesmo ser destruido, o cronometro não funcinará 
e o tiro triplo ficará ativo até o jogo reiniciar
*/

private _tiroTriploLiberado = false;

public void AtivarTiroTriplo()
{
    _tiroTriploLiberado = true;

    // inicia o cronometro
    StartCoroutine(DesativarTiroTriplo())
}

public IEnumerator DesativarTiroTriplo()
{
    yield return new EsperarPorSegundos(10.5f);

    _tiroTriploLiberado = false;
}