# IPv6 Fragen

## Wie kann man folgende IPv6 Adresse möglichst kurz darstellen? 
4563:0000:0000:0076:0000:0000:0000:0a00
* 4563:0:0:76::a00

## Wie lautet die lokale Adresse (loopback) bei IPv6?
* ::1

## Welche Angaben sind für eine vollständige IPv6 Konfiguration nötig?
* Standardgateway (default Route), Adresse (Präfix, Suffix), DNS-Server

## Was versteht man unter RENUMBERING unter IPv6?
* Die Mechanismen zur "stateless" Autokonfiguration erlauben das Hinzufügen und Entfernen von globalen Präfixen und somit die Rekonfiguration eines Netzwerks im laufenden Betrieb. Dank Renumbering lässt sich ein Interface relativ einfach mit neuen Adressen bestücken. Sei es um ein neues Adressschema einzuführen oder den Provider zu wechseln. Ein Interface wird in einen multihomed- ähnlichen Zustand gebracht. Gleichzeitig lässt man die Gültigkeit der alten Adressen langsam auslaufen. Dazu kann man mehrere Netzzugangsrouter unterschiedlich Konfigurieren. Über Router Advertisements kann ein den Hosts sagen "priorisiere mich" und ein anderer Router "benutze mich nicht". Auf diese Weise kann man einen neuen Router in Betrieb und einen anderen außer Betrieb nehmen. Kleine SoHo-Router können das natürlich nicht. 

## Wie schreibt man eine IPv6 url? Nenne ein Beispiel-url für den Webserver unter der Adresse fe00::1 mit https der unter Port 81 läuft..
* https://[fe00:1]:81

## Welche Möglichkeiten gibt es bei IPv6 einen DNS-Server zuzuweisen?
* Ein DNS-Server kann entweder manuell, durch SLAAC oder durch DHCPv6 zugewiesen werden. Bei SLAAC wird RDNSS (Recursive DNS Server) verwendet.

## Wie ist die maximale Paketgröße, die unter IPv4 und IPv6 möglich ist?
* IPv6: Jumbogramm mit 4 Gigabyte
* IPv4: 64535 bytes = 64kByte

## Erkläre den Unterschied zwischen inkrementeller und differentieller Sicherung!
* Ein inkrementelle Sicherung baut auf die letzte Vollsicherung, sowie auf die zuvor erstellten inkrementellen Sicherungen. Es speichert, was sich seit der letzten Sicherung geändert hat.
* Ein differentielle Sicherung baut auf die letzte Vollsicherung auf.

## Nachwelchen Kriterien sollte man die verschiedenen Arten von Daten in Bezug auf Häufigkeit und Wichtigkeit eines Backups unterscheiden?
* Sind es Daten die sich oft ändern (Dokumente etc.) oder Daten die die meiste Zeit über gleich bleiben (Programme etc.)?
* Wie wichtig sind Daten?
* Wie schlimm ist Verlust dieser Daten?
* Wie schnell müssen diese Wiederhergestellt werden können?
* Muss ich jederzeit wieder die Daten herstellen können, oder kann ich es mir leisten, dass ich je nach
* Backup Verfahren ein paar Tage warten muss?
* Wie groß sind die Backups die ich erstelle?
* Will ich auch verschlüsselte Dateien Backupen?
* Wie lange muss ich diese Backups aufbewahren und wiedereinspielen können? 
* Maschinell, Manuell oder gar nicht wiederherstellbar?
* Entstehende Kosten bei der Wiederherstellung(-sdauer)?
