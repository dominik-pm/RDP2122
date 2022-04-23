# DNS Fragen

## In welchem Fall wird beim DNS das TCP-Protokoll verwendet? Erlkäre kurz den Ablauf in diesem Fall!

* Wenn die Paketgröße von 512 bytes (Paketgröße von UDP) überschritten wird. Passiert wenn bspw. ein Zonentransfer stattfindet oder ein großer TXT Record vorhanden ist.

## Nenne 4 Typen von Resource-records und erkläre sie kurz.

* NS - gibt Nameserver an
* A - weißt eine IPv4 Adresse einem Namen zu
* AAAA - weißt eine IPv6 Adresse einem Namen zu
* TXT - für normalen Text der zurückgegeben wird 
* SOA - Start of Authority: gibt Auskunft und Infos über die Zone
* SRV - für Windows AD Dienste, wo sich diese befinden
* CNAME - Weiterleitung (Alias)
* MX - für Mailserver


## Was bedeutet folgender Eintrag und aus welcher Datei des Debian DNS-Server stammt er?
forwarders {
193.171.123.14;
193.171.123.15;
};

* /etc/bind/named.conf.options Datei, wenn DNS Eintrag in lokaler Zone nicht gefunden wird, wird DNS-Anfrage an den hier eingetragenen DNS Server weitergeleitet


## Was ist ein A Record? Was bedeuten die 4 A Records in folgenden zonefile? Kann es überhaupt 4 A Records mit gleicher IP geben?
@ IN SOA htlkrems.ac.at. proxy.htlkrems.ac.at. (200412281 ; serial (d. adams
              3H ; refresh
              15M ; retry
              1W ; expiry
              1D ) ; minimum
              NS proxy.htlkrems.ac.at.
              NS htlkrems.ac.at.
        proxy A 192.168.0.252
        ntserver A 192.168.0.252
        www A 192.168.0.252
        mail A 192.168.0.252

* A Record = ein Name wird einer IPv4-Adresse zugewiesen
* proxy.htlkrems.ac.at ist die IP Adresse 192.168.0.252 zugeordnet
* ntserver.htlkrems.ac.at ist die IP Adresse 192.168.0.252 zugeordnet
* selbes für www und mail
* ja, weil die unterschiedlichen Services die dahinter stehen, ja unterschiedliche Ports verwenden. es sind
also proxy, ntserver, www und mail dienst alle auf einem client installiert, was durchaus sein kann

## Was bedeutet folgender Eintrag aus der named.conf und wann braucht ihn der DNS-Server? 
zone "." {
type hint;
file "/etc/bind/db.root";
};
die datei db.root dazu:
; <<>> DiG 9.2.3 <<>> ns . @a.root-servers.net.
;; global options: printcmd
;; Got answer:
;; ->>HEADER<<- opcode: QUERY, status: NOERROR, id: 18944
;; flags: qr aa rd; QUERY: 1, ANSWER: 13, AUTHORITY: 0, ADDITIONAL: 13
;; QUESTION SECTION:
;. IN NS
;; ANSWER SECTION:
. 518400 IN NS A.ROOT-SERVERS.NET.
. 518400 IN NS B.ROOT-SERVERS.NET.
. 518400 IN NS C.ROOT-SERVERS.NET.
. 518400 IN NS D.ROOT-SERVERS.NET.
. 518400 IN NS E.ROOT-SERVERS.NET.
. 518400 IN NS F.ROOT-SERVERS.NET.
. 518400 IN NS G.ROOT-SERVERS.NET.
. 518400 IN NS H.ROOT-SERVERS.NET.
. 518400 IN NS I.ROOT-SERVERS.NET.
. 518400 IN NS J.ROOT-SERVERS.NET.
. 518400 IN NS K.ROOT-SERVERS.NET.
. 518400 IN NS L.ROOT-SERVERS.NET.
. 518400 IN NS M.ROOT-SERVERS.NET.
;; ADDITIONAL SECTION:
A.ROOT-SERVERS.NET. 3600000 IN A 198.41.0.4
B.ROOT-SERVERS.NET. 3600000 IN A 192.228.79.201
C.ROOT-SERVERS.NET. 3600000 IN A 192.33.4.12
D.ROOT-SERVERS.NET. 3600000 IN A 128.8.10.90
E.ROOT-SERVERS.NET. 3600000 IN A 192.203.230.10
F.ROOT-SERVERS.NET. 3600000 IN A 192.5.5.241
G.ROOT-SERVERS.NET. 3600000 IN A 192.112.36.4
H.ROOT-SERVERS.NET. 3600000 IN A 128.63.2.53
I.ROOT-SERVERS.NET. 3600000 IN A 192.36.148.17
J.ROOT-SERVERS.NET. 3600000 IN A 192.58.128.30 
K.ROOT-SERVERS.NET. 3600000 IN A 193.0.14.129
L.ROOT-SERVERS.NET. 3600000 IN A 198.32.64.12
M.ROOT-SERVERS.NET. 3600000 IN A 202.12.27.33
;; Query time: 81 msec
;; SERVER: 198.41.0.4#53(a.root-servers.net.)
;; WHEN: Sun Feb 1 11:27:14 2004
;; MSG SIZE rcvd: 436 
* wo sich die Datei befindet, wo die ROOT Server Adressen abgespeichert sind
wenn er selber den Eintrag für den Namen der aufgelöst werden sollte nicht hat, schaut DNS hier nach, wo
sich die ROOT Server befinden
also es wird aufgelistet: die verschiedenen Nameserver (ROOT NS in diesem Fall) und welche IP Adresse
diese haben

## Wie kann man die Filterregeln die gerade definiert sind anzeigen?
* für IPTables: iptables -L oder iptables --list
* für NFTables: nft list table ip filter

## Erstelle eine Filterregel mit dem für den IP-Bereich 192.168.0.64-192.168.0.127 FORWARD erlaubt wird.
* iptable -t FILTER -A FORWARD -s 192.168.0.64/26 -j ACCEPT

## Was bewirkt folgende Filterregel?
iptables -t filter -A INPUT -m state --state ESTABLISHED,RELATED -j ACCEPT

* Akzeptiert alle IP-Pakete, die entweder:
-als Antwort einer Anfrage von innen zurückkommen
-oder verwandte Pakete sind (z.B. bei ftp gibt es Port 21 als Verbindungsaufbau und Port 20 als
Datenübertragung)-A INPUT -m state --state ESTABLISHED,RELATED -j ACCEPT

## Wo wurden vor Einführung von BIND die Zuweisungen Hostname - IP-Nummer gespeichert und verändert?
* Auf einem zentralen Rechner in /etc/hosts.txt (/etc/hosts) und alle anderen konnten es von dort
downloaden. (Angaben ohne 🔫)

## Von wem werden die top-level doamins vergeben bzw. verwaltet?
* ICANN (Internet Corporation for Assigned Names and Numbers)

## Welche Funktion ist ein CNAME Eintrag in einem zone-fileund was ist zu beachten bevor man einen CNAME Eintrag machen kann?
* CNAME ist Weiterleitung, Alias. Prüfen, ob der Alias nicht mit bestimmen Kommandowörtern der zone-file konfligiert UND es muss ein A Record oder so etwas zuvor existieren, auf welchen der CNAME weiterleiten kann (kann nicht auf nichts weiterleiten obviously)

## Welche chains gibt es in der iptables Firewall?
* Richtige Reihenfolge: PREROUTING, FORWARD | INPUT, OUTPUT, POSTROUTING

## Wieviele root-Server (nicht IP-Adressen, sondern Rechner) gibt es?
* Um die 100 Rechner, also es gibt 13 IP Adressen, und die sind mehrmals vergeben (RIP Protokoll hat geregelt aufgrund des Standortes etc.)

## Warum ist FTP für viele Firewalls ein Problem?
* Da FTP zwei Ports benutzt: (Port 20 für die Datenübertragung, Port 21 für den Verbindungsaufbau) meist wird Port 20 nicht als Antwort auf Port 21 berücksichtigt und wird von der Firewall gedropt, da nur Port 21 als established-connection von draußen hineingelassen wird (anscheinend nicht ganz richtig 4/5 Punkte)

## Aus welchen drei Hauptkomponenten besteht das DNS-System?
* Auf der Client Seite benötigt man einen Resolver (sozusagen ein DNS Client), der löst den Namen auf die IP-Adresse auf (wird aber fast immer auf einen anderen DNS-Server weiterleiten (Internet Adressen und so) ) 
* Außerdem gibt es noch das Konzept der Top Level Domain, Second Level Domain und der Sub Level Domain 
* wenn User Namen auflösen will, dann fragt er, falls sein eingetragener DNS keinen Eintrag für
* den Namen hat, beim ROOT DNS Server nach, wo sich die TLD befindet, dann sagt der TLD DNS
* Server, wo sich der Server für die Second Level Domain befindet, wo dieser wiederum sagt, wo sich die Sub Level Domain befindet
* es gibt also für Top Level Domains eigene DNS Server, (die ROOT Server wissen wo die sich befinden), dann gibt es für Second Level Domains eigene DNS Server und für Sub Level Domains gibts auch nochmals eigene DNS Server
* zusätzlich dazu Forward oder Cache DNS Server, welche eben häufig aufgerufene Adressen zwischenspeichern (damit man sich dass andauernde nachfragen beim nächsten Server erspart) (Cache Server); forwarder die einfach stumpf jede Anfrage auf einen anderen DNS Server weiterleiten

## Was versteht man unter Zweckentfremdung von ccTLDs (country code Top Level Domains) ? Nenne auch 2 Beispiele!
* dass bestimmte CountryCodes für die Top Level Domain sehr beliebt sind, obwohl das Unternehmen nicht in diesem Land stationiert ist bzw. dass die ccTLD Abkürzungen für andere Sache sind wie z.B. .tv für Fernsehen oder .io für Spiele im Web

## Die Muster (pattern) in den Ketten (chains) der iptables ...
* bestimmt auf welche Pakete die Regel angewendet wird. 

## Welche Kette(n) (chains) werden unmittelbar nach dem Routingprozess durchlaufen?
* INPUT und FORWARD

## Erkläre kurz! den Unterschied zwischen den Zielen DROP und REJECT.
* DROP... das Paket wird ohne Rückmeldung an den Zielrechner weggeworfen
* REJECT... das Paket wird weggeworfen, der Sender wird darüber aber informiert 

## Erstellen Sie eine Regel für IPTables, welche nur proxy (squid) und http auf dem lokalen Rechner auf alles Netzwerkverbidungen zuläßt
* iptables -t FILTER -A INPUT -dport 3128,80 -j ACCEPT 

## Beschreibe kurz die Funktione des MX-Records in der Zonendatei.
* wird verwendet um MailExchange Server zu definieren

## Welche Vorteile gegenüber iptables, bzw welche Ziele haben sich die Entwickler für NFTables gesetzt?
* einen höheren Datendurchsatz
* einfacheren und simpleren Aufbau der Regeln
* eine gemeinsame Codebasis, welche mit Modulen erweitert wird (nicht wie bei iptables, dass der Code für ein anderes Projekt (ebtables, etc.) kopiert wird, und dann Bugs welche in einem Projekt behoben wurden, im anderen Projekt immer noch bestehen)

## Mit welchem Kommandozeilentool bedient man NFTables?
* nft

## Wodurch unterscheiden sich die Chains von iptables zu denen von NFTables?
* in NFTables gibt es grundsätzlich keine Standard Tables oder Chains, diese muss man vorher immer selber erstellen 
* (dass sind in NFTables die sogenannten hooks, diese geben an, wo sich nftables in den network-stack einhängt)

## Was macht folgender NFTables Befehl:
"nft add rule inet filter input tcp dport 22 ct state new,established accept"
* den Port 22 (also SSH) für die INPUT Chain im Filter Table erlauben, und zwar für neue und bereits
etablierte Verbindungen

## Mit welchem Befehl erstellen Sie in NFTables für die Chain INPUT die default policy DROP?
* nft add rule inet input type hook filter policy drop (Angaben ohne 🔫)
