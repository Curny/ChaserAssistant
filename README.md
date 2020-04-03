<h1>ChaserAssistant</h1>

This is a little command-line tool written in C# / MONO to gather information which is interesting for StormChasing.

Currently it supports the open data of the national German weather service (Deutscher Wetterdienst, DWD) which you can find under https://opendata.dwd.de/weather/alerts/txt



Features:

--wl <Region> : Warnlagebericht Region des DWD
	Regionen:
		BB : Berlin + Brandenburg
		BW : Baden-Württemberg
		BY : Bayern
		HE : Hessen
		MV : Mecklenburg-Vorpommern
		NB : Niedersachsen + Bremen
		NRW: Nordrhein-Westfalen
		RPS: Rheinland-Pfalz + Saarland
		SX : Sachsen
		SA : Sachsen-Anhalt
		SHH: Schleswig-Holstein + Hamburg
		TH : Thüringen

 --wv <Region> : Wochenvorhersage
	Regionen:
		DE: Deutschland

 --warn <Autokennzeichen> : aktuelle Wetterwarnungen für Gebiet ausgeben

 --see <Gebiet> : Seewetterwarnungen
	Regionen:
		BO : Boddengewässe Ost
		BS : Belte und Sund
		DB : Deutsche Bucht
		DG : Dogger
		ELB: Elbe von Hamburg bis Cuxhaven
		ELM: Elbmündung
		FE : Fehmarn bis Rügen
		FLF: Flensburg bis Fehmarn
		FI : Fischer
		FO : Forties
		HE : Helgoland
		IJ : Ijsselmeer
		KA : Kattegatt
		KO : Engl. Kanal Ostteil
		KW : Engl. Kanal Westteil
		NOF: Nordfriesische Küste
		NO : Nördliche Ostsee
		OO : Südöstliche Ostsee
		OSF: Ostfriesische Küste
		OSR: östlich Rügen
		RB : Rigaischer Meerbusen
		SK : Skagerrak
		SN : Südwestliche Nordsee
		SO : Südliche Ostsee
		UT : Utsira
		VI : Viking
		WO : Westliche Ostsee
		ZO : Zentrale Ostsee

 --checkdir <URL> : Webverzeichnis auslesen
