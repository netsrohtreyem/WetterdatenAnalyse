//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
//Beschreibung: Fügt Datensätze ein vor oder nach der "position" je nach "vorher"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WetterdatenAnalyse2020.Properties;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static void WetterdatenExportieren(ref Wetterdaten[] Datensaetze)
        {
            int anzahl = 0;
            string fullpath = "";
            string Pfad = Settings.Default.Exportpfad;
            string dateiname = "";
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
                Console.WriteLine("\nEs liegen keine Daten zum Export vor!");
                Console.WriteLine("Weiter mit einer beliebigen Taste!");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
                return;
            }
            else
            { }
            #endregion

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("\nDie Daten werden als .csv Datei gespeichert\n");
            Console.WriteLine("Der Exportpfad lautet: " + Settings.Default.Exportpfad);
            Console.WriteLine("\nGeben Sie einen Dateinamen (ohne Endung!) für die Exportdatei an:");
            dateiname = Console.ReadLine();

            if (!File.Exists(Pfad + @"\" + dateiname + ".csv"))
            {
                DatenSortieren(1, ref Datensaetze, "Datum", true);
                DatenExportieren(Datensaetze, Pfad, dateiname, ref fullpath);
            }
            else
            {
                Console.WriteLine("\n Datei schon vorhanden, überschreiben? (j/n)");
                while (!Console.KeyAvailable) ;
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.J)
                {
                    DatenSortieren(1, ref Datensaetze, "Datum", true);
                    DatenExportieren(Datensaetze, Pfad, dateiname, ref fullpath);
                }
                else
                {
                    Console.WriteLine("Daten wurden nicht exportiert!");
                    Console.WriteLine("Weiter mit einer beliebigen Taste!");
                    while (!Console.KeyAvailable) ;
                    Console.ReadKey(true);
                    return;
                }
            }
            Console.WriteLine("\nDie Daten wurden exportiert in die Datei:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(dateiname + ".csv\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Weiter mit einer beliebigen Taste!");
            while (!Console.KeyAvailable) ;
            Console.ReadKey(true);
            Console.CursorVisible = false;
        }
    }
}