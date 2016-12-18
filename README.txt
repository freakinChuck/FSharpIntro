F# Codebeispiele Readme
by Silvio Stappung / Samuel Bittmann
***************************************************************

1) Installation der Entwicklungsumgebung
----------------------------------------
Um die F# Codebeispiele auszuführen, wird "Microsoft Visual Studio" empfohlen. Visual Studio ist
in der Community-Edition kostenlos verfügbar und kann von folgender Webseite heruntergeladen
werden: https://www.visualstudio.com/de/vs/community/

2) Öffnen der Übungsbeispiele in Visual Studio
----------------------------------------------
Um die Codebeispiele zu öffnen, soll die Datei "FSharpIntro.sln" im Ordner "FSharpIntro" geöffnet 
werden. Je nach dem, ob F# bereits installiert ist, wird man von Visual Studio gebeten, F# zu 
installierern. Dies macht Vistual Studio allerdings weitgehend selbstständig.

Die Verschiedenen Code-Beispiele sind in getrennte Programmdateien mit der Endung .fs abgelegt.
Durch die sprechende Namensgebung sollten die gewünschten Beispiele leicht zu finden sein.
Die Datei "AssemblyInfo.fs" ist lediglich für die Kompilierung notwendig und in diesem Rahmen
nicht weiter interessant. Weiter beinhaltet die Datei "Program.fs" lediglich das Auswahl-Menü für 
die verschiedenen Beispiele.

3) Kompilierung und Laufenlassen der Beispiele
----------------------------------------------
Das Projekt ist so eingerichtet, dass der Code durch das Drücken der Start-Schaltfläche (mit dem
grünen Pfeil) kompiliert und gestartet wird. Daraufhin sollte sich ein Konsolenfenster öffnen,
in welchem ein Text-Menü angezeigt wird. Diese Menü enthält alle Beispiele, die durch die
Eingabe der entsprechenden Nummer, gefolgt von einem Enter, ausgewählt werden können.

################################################################################################
#                                      !!!Wichtig!!!                                           #
# Der Code kompiliert nur, wenn die Datei "Program.fs" im Projektmappen-Explorer-Fenster ganz  #
# am schluss steht. Sollte dies aus irgend einem Grund nicht der Fall sein, kann die Datei     #
# durch Auswählen und mehrmaligem Drücken der Alt- und der Pfeil-nach-unten-Taste nach unten   #
# verschoben werden. Will man den Code ausserhalb von Visual Studio kompilieren, muss man      #
# ebenfalls darauf achten, dass diese Datei in der Kompilierungsreihenfolge ganz am Schluss    #
# kommt.                                                                                       #
################################################################################################