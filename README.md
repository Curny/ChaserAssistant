<h1>ChaserAssistant</h1>

This is a little command-line tool written in C# / MONO to gather information which is interesting for StormChasing.

Currently it supports the open data of the national German weather service (Deutscher Wetterdienst, DWD) which you can find under https://opendata.dwd.de/weather/alerts/txt

<br><br>

Features:
<br><br>
--wl <Region> : Warnlagebericht Region des DWD<br>
	Regionen:<br>
		BB : Berlin + Brandenburg<br>
		BW : Baden-Württemberg<br>
		BY : Bayern<br>
		HE : Hessen<br>
		MV : Mecklenburg-Vorpommern<br>
		NB : Niedersachsen + Bremen<br>
		NRW: Nordrhein-Westfalen<br>
		RPS: Rheinland-Pfalz + Saarland<br>
		SX : Sachsen<br>
		SA : Sachsen-Anhalt<br>
		SHH: Schleswig-Holstein + Hamburg<br>
		TH : Thüringen<br><br>

 --wv <Region> : Wochenvorhersage<br>
	Regionen:<br>
		DE: Deutschland<br><br>

 --warn <Autokennzeichen> : aktuelle Wetterwarnungen für Gebiet ausgeben<br><br>

 --see <Gebiet> : Seewetterwarnungen<br>
	Regionen:<br>
		BO : Boddengewässe Ost<br>
		BS : Belte und Sund<br>
		DB : Deutsche Bucht<br>
		DG : Dogger<br>
		ELB: Elbe von Hamburg bis Cuxhaven<br>
		ELM: Elbmündung<br>
		FE : Fehmarn bis Rügen<br>
		FLF: Flensburg bis Fehmarn<br>
		FI : Fischer<br>
		FO : Forties<br>
		HE : Helgoland<br>
		IJ : Ijsselmeer<br>
		KA : Kattegatt<br>
		KO : Engl. Kanal Ostteil<br>
		KW : Engl. Kanal Westteil<br>
		NOF: Nordfriesische Küste<br>
		NO : Nördliche Ostsee<br>
		OO : Südöstliche Ostsee<br>
		OSF: Ostfriesische Küste<br>
		OSR: östlich Rügen<br>
		RB : Rigaischer Meerbusen<br>
		SK : Skagerrak<br>
		SN : Südwestliche Nordsee<br>
		SO : Südliche Ostsee<br>
		UT : Utsira<br>
		VI : Viking<br>
		WO : Westliche Ostsee<br>
		ZO : Zentrale Ostsee<br><br>

 --checkdir <URL> : Webverzeichnis auslesen
