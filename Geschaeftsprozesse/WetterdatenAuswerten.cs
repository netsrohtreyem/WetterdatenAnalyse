//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static void WetterdatenAuswerten(Wetterdaten[] Datensaetze)
        {
            int anzahl = 0;
            Durchschnitt Ergebnis = DurchschnittBerechnen(Datensaetze);

            #region Zählen
            foreach (Wetterdaten wd in Datensaetze)
            {
                if (wd.Luftdruck >= 700)
                {
                    anzahl++;
                }
                else
                { }
            }
            if (anzahl <= 0)
            {
                Console.WriteLine("\nEs liegen keine Daten zur Auswertung vor!");
                Console.WriteLine("Weiter mit einer beliebigen Taste!");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
                return;
            }
            #endregion

            int indextemp = -1;
            int indexdruck = -1;
            int indexfeucht = -1;
            int indextempmin = -1;
            int indexdruckmin = -1;
            int indexfeuchtmin = -1;
            string maxtemp = GetMax(Datensaetze, "Temperatur", anzahl, ref indextemp);
            string maxdruck = GetMax(Datensaetze, "Luftdruck", anzahl, ref indexdruck);
            string maxfeucht = GetMax(Datensaetze, "Luftfeuchtigkeit", anzahl, ref indexfeucht);
            string mintemp = GetMin(Datensaetze, "Temperatur", anzahl, ref indextempmin);
            string mindruck = GetMin(Datensaetze, "Luftdruck", anzahl, ref indexdruckmin);
            string minfeucht = GetMin(Datensaetze, "Luftfeuchtigkeit", anzahl, ref indexfeuchtmin);
            Console.Clear();
            Console.WriteLine("\n\n\n                            Auswertung der Wetterdaten");
            Console.WriteLine("\n       Es liegen " + anzahl + " Datensätze vor.");
            Console.WriteLine("\n       Die Durchschnittswerte betragen:");
            Console.WriteLine("       Tempertatur: " + Ergebnis.Temperatur.ToString("F2") + " °C");
            Console.WriteLine("       Luftdruck: " + Ergebnis.Luftdruck.ToString("F1") + " hPa");
            Console.WriteLine("       Luftfeuchtigkeit: " + Ergebnis.Luftfeuchtigkeit.ToString("F1") + " %");
            Console.WriteLine("       Zurück mit einer beliebigen Taste");
            Console.WriteLine("\n       Die Maximalwerte betragen:");
            Console.WriteLine("       Tempertatur: " + maxtemp + " °C, am " + Datensaetze[indextemp].Datum);
            Console.WriteLine("       Luftdruck: " + maxdruck + " hPa, am " + Datensaetze[indexdruck].Datum);
            Console.WriteLine("       Luftfeuchtigkeit: " + maxfeucht + " %, am " + Datensaetze[indexfeucht].Datum);
            Console.WriteLine("\n       Die Minimalwerte betragen:");
            Console.WriteLine("       Tempertatur: " + mintemp + " °C, am " + Datensaetze[indextempmin].Datum);
            Console.WriteLine("       Luftdruck: " + mindruck + " hPa, am " + Datensaetze[indexdruckmin].Datum);
            Console.WriteLine("       Luftfeuchtigkeit: " + minfeucht + " %, am " + Datensaetze[indexfeuchtmin].Datum);
            Console.WriteLine("\n       zurück mit einer beliebigen Taste!");
            while (!Console.KeyAvailable) ;
            Console.ReadKey(true);
        }
    }
}