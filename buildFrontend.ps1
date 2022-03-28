if (Get-Command "node" -ErrorAction SilentlyContinue) 
{ 
    Write-Output "Znaleziono NODEJS w wersji: "
    node --version
}
else
{
    Write-Output "NIE znaleziono NODE JS - upewnij sie, ze program program zostal" 
    Write-Output "zainstalowany poprawnie i jest dopisany do zmiennej PATH." 
    return
}

Write-Output ""

Write-Output "Sprawdzanie zakonczonczone sukcesem."

Write-Output "Pobieranie potrzebnych bibliotek JS"
cd ./FrontEnd


Write-Output "Lokalna instalacja angular cli"

npm install @angular/cli@12

if ($LASTEXITCODE -ne 0)
{
    return
}

Write-Output "Instalacja pakietow"

cd ./ExchangeRatesReader

npm install

if ($LASTEXITCODE -ne 0)
{
    return
}

Write-Output "Budowanie aplikacji"

ng build

