<h1>ChaserAssistant</h1>

<b>EARLY development stage!</b>

<i>Don't expect beauty at the moment, I'm more busy with getting all the text files read as the service does not offer API or JSON, only text files on the web server.</i>

This is a little command-line tool written in C# / MONO to gather information which is interesting for StormChasing.

Currently it supports the open data of the national German weather service (Deutscher Wetterdienst, DWD) which you can find under https://opendata.dwd.de/weather/alerts/txt

V0.1:

--help            zeigt eine kurze Hilfe an, die auch die vom DWD verwendeten Regionen enthält<br>
--wl <region>     zeigt den Warnlagebericht der betreffenden Region<br>
--wv <region>     zeigt die Wochenvorhersage der betreffenden Region. Bisher nur DE
