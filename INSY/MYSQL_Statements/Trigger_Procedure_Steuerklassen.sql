-- Author: Sebastian Leutgeb
-- Unterrichtseinheit: 08.04.2022, INSY
-- Aufgabenstellung: Mithilfe von Trigger und Procedures das einfügen falscher Werte verhindern

-- ---------------------------------------------------------------------------------------------------------------------------------
-- Datenbank erstellen und mit richtigen Werten befüllen
-- ---------------------------------------------------------------------------------------------------------------------------------
create database if not exists steuern;

use steuern;

create or replace table Steuerstufen (
    stufe int PRIMARY KEY,
    breite int check ( breite >= 0 ),
    proz decimal(3, 3) not null
);

INSERT INTO Steuerstufen (stufe, breite, proz)
VALUES (1, 11000, 0),
       (2, 7000, 0.20),
       (3, 13000, 0.325),
       (4, 29000, 0.42),
       (5, 30000, 0.48),
       (6, 910000, 0.50),
       (7, null, 0.55);

-- ---------------------------------------------------------------------------------------------------------------------------------
-- Procedures, welche auf richtige Werte überprüfen
-- ---------------------------------------------------------------------------------------------------------------------------------
Create or replace procedure SteuerCheck(newStufe int, newBreite int, newProz decimal(3, 3))
    Begin
        if (select COUNT(stufe) from steuerstufen where (stufe < newStufe and proz >= newProz) or (stufe > newStufe and proz <= newProz) group by null) > 0
        then
            signal sqlstate '45000' set message_text = 'Percentage is not allowed at this place!';
        end if;

        if (select COUNT(stufe) from steuerstufen where stufe < newStufe and breite is null group by null) > 0
        then
            signal sqlstate '45000' set message_text = 'There is a null-size before!';
        end if;

        if newBreite is null and (select COUNT(stufe) from steuerstufen where stufe > newStufe and breite is null group by null) > 0
        then
            signal sqlstate '45000' set message_text = 'There is a null-size after!';
        end if;
    end;

create or replace trigger InsertSteuer
    Before INSERT
    On steuerstufen
    for each row
    BEGIN
        call SteuerCheck(NEW.stufe, NEW.breite, new.proz);
    end;

create or replace trigger UpdateSteuer
    Before UPDATE
    On steuerstufen
    for each row
    BEGIN
        call SteuerCheck(NEW.stufe, NEW.breite,new.proz);
    end;

-- ---------------------------------------------------------------------------------------------------------------------------------
-- Testfälle 
-- ---------------------------------------------------------------------------------------------------------------------------------

create database if not exists steuern;

use steuern;

create or replace table Steuerstufen (
    stufe int PRIMARY KEY,
    breite int check ( breite >= 0 ),
    proz decimal(3, 3) not null
);

INSERT INTO Steuerstufen (stufe, breite, proz)
VALUES (1, 11000, 0),
       (2, 7000, 0.20),
       (3, 13000, 0.325),
       (4, 29000, 0.42),
       (5, 30000, 0.48),
       (6, 910000, 0.50),
       (7, null, 0.55);