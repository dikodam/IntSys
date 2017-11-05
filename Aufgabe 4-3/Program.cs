using System;

namespace Aufgabe_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@"
Als EntwicklerIn nehmen Sie an einer Besprechung mit UI-Designern teil. 
Diese schlagen eine Benutzerschnittstelle vor, die Ziele bei Annäherung
des Mauszeigers vergrößert.

a) Warum ist dieses Verhalten aus Sicht von Fitts’ Gesetz vorteilhaft 
für den Benutzer? Begründen Sie unter Bezugnahme auf Variablen in 
Fitts’ Formel.

MT = a + b * log_2( A / W + 1 )

Für unsere Betrachtung ist a und b irrelevant, da wir nichts Näheres 
über das Gerät wissen. Somit bleibt uns der index of difficulty (ID).

ID = log_2( A / W + 1 )

Wobei A (Amplitude) die Distanz vom Start zum Ziel darstellt und W
(Width) die Breite des Ziels, gemessen in der Bewegungsrichtung.
Wenn sich nun das Ziel vergrößert steigt W und A sinkt. Dadurch wird
der Quotient kleiner und somit auch der Index of Difficulty da dieser
sonst nur von Konstanten abhängt. Daher ist diese Veränderung auf den
ersten Blick, aus Sicht der Benutzer vorteilhaft.


b) In der Diskussion fallen die Begriffe Over- und Undershooting. 
Worum handelt es sich dabei, und welcher Aspekt der geplanten 
Benutzerschnittstelle sollte sich daran orientieren?

Over- und Undershooting meint, dass jemand über das Ziel hinausfährt
oder davor stoppt. Um dies zu verhindern sollten die Ziele (also alle
Elemente welche anklickbar seien sollen) gleich groß sein, und ihre 
Größe nicht ändern, um Kongruenz  zwischen visuellem Eindruck,
Erwartung und Realität her zu stellen.
"
            );
        }
    }
}
