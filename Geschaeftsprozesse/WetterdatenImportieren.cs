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
        static void WetterdatenImportieren(ref Wetterdaten[] Datensaetze)
        {
            int anzahl = 0;
            int anzahl_neu = 0;
            int nummer = 0;
            bool ok = false;
            string Pfad = Settings.Default.Importpfad;
            string dateiname = "";
            //Ordner?
            if (!Directory.Exists(Pfad))
            {
                Directory.CreateDirectory(Pfad);
            }
            else
            { }

            string[] Liste = Directory.GetFiles(Pfad);
            if (Liste.Length <= 0)
            {
                Console.WriteLine("\nEs liegen keine Dateien zum Import vor!");
                Console.WriteLine("Weiter mit einer beliebigen Taste!");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
                return;
            }
            else
            { }
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
            #endregion

            //Liste der Dateien anzeigen und eine auswählen
            do
            {
                Console.Clear();
                Console.WriteLine("Quellordner:");
                Console.WriteLine(Settings.Default.Importpfad + "\n");
                Console.WriteLine(Liste.Length + " Datei(en) vorhanden\n");
                Console.CursorVisible = false;
                int index = 1;
                string format = "{0,-5}{1,-70}";
                foreach (string dat in Liste)
                {
                    string anzstr = dat.Substring(dat.LastIndexOf("\\") + 1);
                    Console.WriteLine(format, index + ": ", anzstr);
                    index++;
                }
                //Dateiname einlesen
                Console.CursorVisible = true;
                Console.WriteLine("\nGeben Sie die Nummer der Datei an, mit return bestätigen (abbrechen mit ESC)");
                while (!Console.KeyAvailable) ;
                ConsoleKeyInfo input = Console.ReadKey(false);
                if (input.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else
                { }
                try
                {
                    nummer = Convert.ToInt32(input.KeyChar + Console.ReadLine());
                    if (nummer > 0 && nummer <= Liste.Length)
                        ok = true;
                }
                catch (Exception)
                {
                    ok = false;
                }
            } while (!ok);
            dateiname = Liste[nummer - 1].Substring(Liste[nummer - 1].LastIndexOf("\\") + 1);

            //Daten auslesen
            ok = DatenImportieren(ref Datensaetze, Pfad, dateiname, ref anzahl_neu);

            if (ok)
            {
                Console.WriteLine("\n" + anzahl_neu + " Datensätze wurden importiert aus der Datei:\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dateiname + ".csv\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Weiter mit einer beliebigen Taste!");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
                Console.CursorVisible = false;
            }
            else
            {
                Console.WriteLine("\nEs wurden keine Datensätze importiert");
                Console.WriteLine("Weiter mit einer beliebigen Taste!");
                while (!Console.KeyAvailable) ;
                Console.ReadKey(true);
                Console.CursorVisible = false;
            }
        }
    }
}