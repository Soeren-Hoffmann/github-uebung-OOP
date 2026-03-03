# OOP anhand eines Spiels

## Ziel

Ein einfaches 2D-Spiel in dem ein Spieler rundenbasiert Monster besiegen kann.

## Leitfragen

### Abstraktion: Komplexität reduzieren

- Was ist die Verantwortung dieser Klasse?
- Gibt es eine höhere Ebene (Vererbung)
- Welche Daten/Methoden sind für Nutzer relevant?
- Welche Daten/Methoden sind interne Details?

### Kapselung: Innere Zustände schützen, Invarianten einhalten

- Welche Invarianten müssen immer gelten?
- Welche Attribute/Felder sollen nicht direkt änderbar sein?
- Wie kann das Objekt von Außen in einen ungültigen Zustand kommen?
- Welche Methoden sind Teil des öffentlichen Vertrags? Was ist nur Hilfslogik

### Vererbung: Gemeinsames Verhalten teilen über echte Beziehungen

folgt

### Polymorphismus: Wie vermeiden wir Typ-Checks durch einheitliche Aufrufe?

folgt

## Regeln

### Bewegung/Spielfeld

- X ist horizontal
- Y ist vertikal

**Beispiel**

- Spieler (S) mit `X = 0, Y = 0`
- Gegner (G) mit `X = 2, Y = 1`
- 3 mal 3 Feld:

```
S  
  X
   
```

Alles wird als Spielfigur dargestellt. Sie ist nullable.

### Kampf

- Waffen:
- Spieler:
- Monster/Gegner:

## Klassen

```mermaid
classDiagram
    %% Spiellogik:

    Spielwelt: +const int size_x
    Spielwelt: +const int size_y
    Spielwelt: -Spielfigur[][2] fields
    Spielwelt: +bool besetzt(int x_pos, int y_pos)
    Spielwelt: +belegeFeld(Spielfigur f, int x_pos, int y_pos)
    Spielwelt: +entferne(Spielfigur f)

    Spielfigur: +Spielfigur(const int schutz_schlagschaden, const int schutz_klingenschaden, String name, int reichweite, Waffe ausgerüstet)
    Spielfigur: +const int schutz_schlagschaden
    Spielfigur: +const int schutz_klingenschaden
    Spielfigur: +String name
    Spielfigur: -int reichweite
    Spielfigur: -Waffe ausgerüstet
    Spielfigur: +Waffe getWaffe()
    Spielfigur: +schadenNehmen(int anzahlSchaden)
    Spielfigur: +zieheAufFeld(int x, int y)
%% Spielfigur ist nullable -> unbesetztes Feld


Waffe: +const int[2] schlagschaden
Waffe: +const int[2] klingenschaden
Waffe: +const int reichweite
%% schlagschaden[0] = 1
%% schlagschaden[1] = 10

Kampfsystem: +int schadenBerechnen(int anzahlSchaden, Spielfigur an)
Kampfsystem: +bool istAngreifbar(Spielfigur angreifer, Spielfigur verteidiger)

%% 1. Spielwelt anlegen
%% 2. Waffen anlegen
%% 3. Spieler und Monster anlegen
%% 4. Spielwelt füllen (Spieler und Monster)
%% 5. Spiellogik (Spieler bewegt sich Kampf findet statt)
```


## Contributions für Umschüler (wie mache ich mit?)

1. Du bekommst eine `.bundle` Datei von mir.
2. Klone und wechsle in das Verzeichnis:
```
git clone dateiname.bundle dateiname-deineID
cd dateiname-deineID
``` 
3. Setze zur Sicherheit Deinen Namen und Deine E-Mail
```
git config user.name "Max Mustermann"
git config user.email "max@example.com"
```

2. Du wechselst auf Deinen Branch (benannt nach internen ID): `git checkout -b submission/deineID`
3. Du beginnst an den Aufgaben zu arbeiten. Zwischendurch `git status` prüfen. Dann nach getesteten, sinnvollen Änderungen:
```
git add .
git commit -m "sinnvolle Beschreibung, was du geändert hast"
```
4. Den Commit-Verlauf kannst Du Dir z.B. so ansehen: `git log --oneline --decorate --graph`
5. Wenn Du es mit uns teilen willst, bundle erzeugen: `git bundle create deineID-01.bundle submission/deineID` wobei `01` frei wählbar ist, aber am besten beschreibt, zu welchem Zeitpuntk z.B. Wochentag, das gemacht wurde.
6. Du prüfst, ob es sauber geklappt hat: `git bundle verify deineID-01.bundle`
7. Du gibst die erstellte Datei an mich: `deineID-01.bundle`

Rausfinden, auf welchem Branch Du Dich befindest kannst Du mit `git branch --show-current`
