Potrebni programi za appium:

	- node.js : https://nodejs.org/en/download/
	- appium : https://github.com/appium/appium-desktop/releases/tag/v1.15.1
	- AndroidSDK : najbolje instalirati koriscenjem visual studion instaler, ujedno instalra ce i simulator.
	- JavaSDK

Prilikom pokretanja appiuma pre startovanja servera treba da se provere dali su putanje do Androidsdk i java.

Da bi se koristio appium u c# projekat potrebno je preko nugeta da se skine Appium.WebDriver

json:
	- config : Konfiguracija putanja do potrebnih programa :
		- nodeBinaryPath : primer "C:\\Program Files\\nodejs\\node.exe".
		- appiumBinaryPath : primer : "C:\\Program Files\\Appium\\resources\\app\\node_modules\\appium\\build\\lib\\main.js"
		- androidSDKPath : primer : "C:\\Program Files (x86)\\Android\\android-sdk"
	-phoneConfig : Potrebna kofiguracija da bi se povezala sa telefonom:
		- deviceName : ime uredjaja, moze da se dobije koriscenjem adb.
		- platformName 
		- platformVersion
	-appConfig : Potrebna konfiguracija za aplikaciju koja treba se testira:
		- appPackage
		- appActivity
	-testData : lista koraka koja treba da se izvrsava prilikom testiranja:
		- step :
			- by : preko cega se element trazi (id, xpath, ...).
			- elementName : id ili xpath trazenog elementa.
			- testType : akcija koja treba da se izvrsi nad elementom (click, input, ...).
			- inputValue : vrednos koja se unosi
	- resaultConfig : konfiguracija resaultata:
		- resaultType : tip izlaznog rezultata (value, screanShoot).
		- by : preko cega se element trazi (id, xpath, ...).
		- elementName : id ili xpath trazenog elementa.
		- resaultValue : resultat koji ocekujemo.
		- screenShootEveryStep : dali nakon svakog koraka treba screenshoot.