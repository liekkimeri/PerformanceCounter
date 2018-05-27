# PerformanceCounter
wcf- toteutettu clien-server ohjelmisto jonka avulla voi wep api kautta tarkastella koneiden kuormitusta ja ip-osoitteita

Luo mssql-tietokanta, jonka nimi on PerformanceCounter ja luo tietokanta taulut ajamalla PerformanceCounterCreateDb.sql niminen tietokanta skripti

PerformanceCounterServerin:

Käynnistä visual studio administraattori-modessa ja vaihda ip-osoite (Uri BaseAddress) vastaamaan konetta jossa ajat serviceä ja vaihda tietokanta instansi nimi (networkDBInstance).
Käännä koodi ja laita serveri päälle. Serveria pitää ajaa windowsissa administraattori-modessa

PerformanceCounterServerin:

Käynnistä Developer Command Prompt for vs ja meni kansinoon, jos sijatsee generatedProxy.cs nimen tiedosto ja ajan Command Prompt for vs komento "svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/PerformanceCounter/Service" (korvaa localhosti ip-ositteella jonka olet asettanut serveriin).
Käännä koodi ja laita clienti päällä

PerformanceCounterWebApi:
Ohjelman on tehty käyttäen asp.net wep api ja entity framework.  
Vaihda web.config tiedostossa connectionStrings oleva data suorce vastaamaan sinun tietokanta instanssia
Käännä koodi ja laita webApi päällä 

WepApi-kutsut:
api/PerformanceCounter --palauttaa id, koneen nimen, ip , viimeisen cpu-kuoritusarvoin % ,viimeisen vapaan ram-muistin määrän ja viimeisen kovalevy vapaan tilan ja aikaleiman koska viimeinen päivitys on tehty.
PerformanceCounter/{id}  ----palauttaa koneen nimen, ip , viimeisen vuorokauden ajalta cpu-kuoritusarvoin % ,viimeisen vuorokauden ajalta vapaan ram-muistin määrän ja viimeisen vuorokauden ajalta kovalevy vapaan tilan ja aikaleimat. Palauttaa noin 71600 mittausarvoa.
