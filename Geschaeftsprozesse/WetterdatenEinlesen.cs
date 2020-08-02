//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
//Beschreibung: Fügt Datensätze ein vor oder nach der "position" je nach "vorher"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WetterdatenAnalyse2020.Properties;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static void WetterdatenEinlesen(ref Wetterdaten[] Datensaetze, int position, bool vorher)
        {
            int freieplaetze = 0;
            int anzahl = 0;
            int index = 1;
            Wetterdaten anposition;
            Wetterdaten nachposition;
            Wetterdaten vorposition;
            Wetterdaten neuerDatensatz;
            neuerDatensatz.Datum = "";
            neuerDatensatz.Temperatur = 0.0;
            neuerDatensatz.Luftdruck = 0;
            neuerDatensatz.Luftfeuchtigkeit = 0;
            Console.CursorVisible = true;

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

            #region Position prüfen
            //nachher
            if (position > 0 && !vorher && position <= anzahl)
            {
                anposition = Datensaetze[position - 1];
                nachposition = Datensaetze[position];
                freieplaetze = 366 - anzahl;
            }
            //vorher
            else if (position > 1 && vorher && position <= anzahl)
            {
                anposition = Datensaetze[position - 1];
                vorposition = Datensaetze[position - 2];
                freieplaetze = 366 - anzahl;
            }
            //Vor den Anfang
            else if (position == 1)
            {
                freieplaetze = 366 - anzahl;
            }
            //Hinter das Ende
            else if (position >= anzahl || position < 0)
            {
                freieplaetze = 366 - anzahl;
            }
            else
            {
                Console.WriteLine("Falsche Einfügeposition angegeben");
                Console.WriteLine("Es kann nicht hinzugefügt werden, weiter mit einer beliebige Taste");
                while (!Console.KeyAvailable) ;
                Console.ReadKey();
                return;
            }
            #endregion

            # region Datensaetze einlesen, prüfen und einfügen
            int Menge = 0;
            int Mengetotal = 0;
            bool ok = true;

            //Einlesen
            do
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.Write("Wieviele Datensätze möchten Sie eingeben?\n(max. sind " + freieplaetze.ToString() + " möglich, " + anzahl + " sind belegt)\n");
                try
                {
                    Menge = Convert.ToInt32(Console.ReadLine());
                    Mengetotal = Menge;
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("nur Ziffer sind erlaubt!");
                    Console.WriteLine("weiter mit beliebiger Taste");
                    while (!Console.KeyAvailable) ;
                    Console.ReadKey(true);
                    ok = false;
                    continue;
                }
                if (Menge > freieplaetze)
                {
                    ok = false;
                    Console.WriteLine("Nicht genügend Speicherplatz für " + Menge + " Element!");
                    Console.WriteLine("Es sind schon " + anzahl + " Plätze von max. 366 belegt!");
                    Console.WriteLine("weiter mit einer beliebigen Taste oder Abbrechen mit ESC");
                    while (!Console.KeyAvailable) ;
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    else
                    { }
                }
                else
                {
                    ok = true;
                }
            } while (!ok);

            string Datum = neuerDatensatz.Datum;
            string Temperatur = "";
            string Luftdruck = "";
            string Luftfeuchtigkeit = "";
            do
            {
                ConsoleKeyInfo input;
                Console.Clear();
                Console.Write("\nDatensatz " + index + " von " + Menge +
                                  " eingeben (Abbrechen jederzeit mit ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("'ESC'");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("):\n");
                #region Datum
                Console.WriteLine("\nDatum (tt.mm.jjjj): ");
                if (neuerDatensatz.Datum == "")
                {
                    while (!Console.KeyAvailable) ;
                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Escape)
                    {
                        Console.CursorVisible = false;
                        break;
                    }
                    else if (input.Key == ConsoleKey.Backspace)
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(" ");
                        Console.CursorLeft = Console.CursorLeft - 1;
                    }
                    else
                    { }

                    Datum = input.KeyChar + Console.ReadLine();
                    DateTime tmpdate;
                    //Prüfen
                    bool nochmal = !DateTime.TryParse(Datum, out tmpdate);
                    if (nochmal)
                    {
                        Console.WriteLine("\nFalsches Datumformat,\n weiter mit einer beliebigen Taste");
                        while (!Console.KeyAvailable) ;
                        Console.ReadKey(true);
                        continue;
                    }
                    else
                    {
                        //Datensatz vorhanden?
                        bool vorhanden = false;
                        foreach (Wetterdaten daten in Datensaetze)
                        {
                            if (daten.Datum == tmpdate.ToShortDateString())
                            {
                                vorhanden = true;
                                Console.WriteLine("\nDatensatz schon vorhanden!,\n weiter mit einer beliebigen Taste");
                                while (!Console.KeyAvailable) ;
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            { }
                        }
                        if (!vorhanden)
                        {
                            neuerDatensatz.Datum = tmpdate.ToShortDateString();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(neuerDatensatz.Datum);
                }
                #endregion

                #region Temperatur
                bool tempok = false;
                do
                {
                    //Prüfen
                    Console.WriteLine("\nTemperatur °C (-50°C - 60°C): ");
                    if (Temperatur == "")
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            tempok = false;
                            Mengetotal = 0;
                            break;
                        }
                        else if (input.Key == ConsoleKey.Backspace)
                        {
                            Console.CursorLeft = Console.CursorLeft - 1;
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                        }
                        else
                        { }
                        Temperatur = input.KeyChar + Console.ReadLine();

                        double tempwert;
                        int poskomma = Temperatur.IndexOf('.');
                        if (poskomma > -1)
                        {
                            Temperatur = Temperatur.Replace('.', ',');
                        }
                        else
                        {
                        }
                        tempok = double.TryParse(Temperatur, out tempwert);

                        if (!tempok || tempwert < -50 || tempwert > 60)
                        {
                            Console.WriteLine("\n Der Temperaturwert ist falsch (-50°C <-> +60°C)!,\n weiter mit einer beliebigen Taste");
                            Temperatur = "";
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            tempok = false;
                            continue;
                        }
                        else
                        {
                            //Speichern
                            neuerDatensatz.Temperatur = tempwert;
                            tempok = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine(Temperatur);
                        neuerDatensatz.Temperatur = Convert.ToDouble(Temperatur);
                        tempok = true;
                    }
                } while (!tempok);
                if (!tempok)
                {
                    continue;
                }
                else
                { }
                #endregion

                #region Luftdruck
                tempok = false;
                do
                {
                    Console.WriteLine("\nLuftdruck hPa (700 - 1080): ");
                    if (Luftdruck == "")
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            tempok = false;
                            Mengetotal = 0;
                            break;
                        }
                        else if (input.Key == ConsoleKey.Backspace)
                        {
                            Console.CursorLeft = Console.CursorLeft - 1;
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                        }
                        else
                        { }
                        Luftdruck = input.KeyChar + Console.ReadLine();
                        //Prüfen
                        uint druckwert;
                        tempok = UInt32.TryParse(Luftdruck, out druckwert);
                        if (!tempok || druckwert < 700 || druckwert > 1080)
                        {
                            Console.WriteLine("\n Der Luftdruckwert ist falsch (700 hPa - 1080hPa)!,\n weiter mit einer beliebigen Taste");
                            Luftdruck = "";
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            tempok = false;
                            continue;
                        }
                        else
                        {
                            neuerDatensatz.Luftdruck = druckwert;
                            tempok = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine(Luftdruck);
                        neuerDatensatz.Luftdruck = Convert.ToUInt32(Luftdruck);
                        tempok = true;
                    }
                } while (!tempok);
                if (!tempok)
                {
                    continue;
                }
                else
                { }
                #endregion

                #region Luftfeuchtigkeit
                tempok = false;
                do
                {
                    Console.WriteLine("\nLuftfeuchtigkeit % (0-100): ");
                    if (Luftfeuchtigkeit == "")
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            tempok = false;
                            Mengetotal = 0;
                            break;
                        }
                        else if (input.Key == ConsoleKey.Backspace)
                        {
                            Console.CursorLeft = Console.CursorLeft - 1;
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                        }
                        else
                        { }
                        Luftfeuchtigkeit = input.KeyChar + Console.ReadLine();
                        //Prüfen
                        uint feuchtewert;
                        tempok = UInt32.TryParse(Luftfeuchtigkeit, out feuchtewert);
                        if (!tempok || feuchtewert < 0 || feuchtewert > 100)
                        {
                            Console.WriteLine("\n Der Luftfeuchtewert ist falsch (0% - 100%)!,\n weiter mit einer beliebigen Taste");
                            Luftfeuchtigkeit = "";
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            tempok = false;
                            continue;
                        }
                        else
                        {
                            neuerDatensatz.Luftfeuchtigkeit = feuchtewert;
                            tempok = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine(Luftfeuchtigkeit);
                        neuerDatensatz.Luftfeuchtigkeit = Convert.ToUInt32(Luftfeuchtigkeit);
                        tempok = true;
                    }
                } while (!tempok);
                if (!tempok)
                {
                    continue;
                }
                else
                { }
                #endregion

                bool fertig = false;
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n<- ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("zurück               ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(S)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("ichern                   weiter");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("->");
                Console.ForegroundColor = ConsoleColor.Gray;

                do
                {
                    while (!Console.KeyAvailable) ;
                    input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.LeftArrow)
                    {
                        Datum = "";
                        neuerDatensatz.Datum = "";
                        Temperatur = "";
                        Luftdruck = "";
                        Luftfeuchtigkeit = "";
                        break;
                    }
                    else if (input.Key == ConsoleKey.RightArrow || input.KeyChar == 's' || input.KeyChar == 'S')
                    {
                        fertig = true;
                        Console.CursorVisible = false;
                        Mengetotal--;
                        if (position < 0)
                        {
                            position = anzahl;
                        }
                        else
                        { }

                        if (vorher)
                        {
                            Wetterdaten[] neuesArray = new Wetterdaten[Datensaetze.Length];
                            //Anfang kopieren
                            for (int index1 = 0; index1 < position - 1; index1++)
                            {
                                neuesArray[index1] = Datensaetze[index1];
                            }
                            //Neues Element
                            neuesArray[position - 1] = neuerDatensatz;
                            //Ende kopieren
                            for (int index1 = position; index1 <= anzahl; index1++)
                            {
                                neuesArray[index1] = Datensaetze[index1 - 1];
                            }
                            //Zeiger umbiegen
                            Datensaetze = neuesArray;
                            Datum = "";
                            neuerDatensatz = new Wetterdaten();
                            neuerDatensatz.Datum = "";
                            Temperatur = "";
                            Luftdruck = "";
                            Luftfeuchtigkeit = "";
                        }
                        else
                        {
                            Wetterdaten[] neuesArray = new Wetterdaten[Datensaetze.Length];
                            //Anfang kopieren
                            for (int index1 = 0; index1 < position; index1++)
                            {
                                neuesArray[index1] = Datensaetze[index1];
                            }
                            //Neues Element
                            neuesArray[position] = neuerDatensatz;
                            //Ende kopieren
                            for (int index1 = position + 1; index1 <= anzahl; index1++)
                            {
                                neuesArray[index1] = Datensaetze[index1 - 1];
                            }
                            //Zeiger umbiegen
                            Datensaetze = neuesArray;
                            Datum = "";
                            neuerDatensatz = new Wetterdaten();
                            neuerDatensatz.Datum = "";
                            Temperatur = "";
                            Luftdruck = "";
                            Luftfeuchtigkeit = "";
                        }
                    }
                    else if (input.Key == ConsoleKey.Escape)
                    {
                        fertig = true;
                        Console.CursorVisible = false;
                        Mengetotal = 0;
                    }
                    else
                    { }
                } while (!fertig);
                index++;
                position++;
                anzahl++;
            } while (Mengetotal > 0);
            #endregion
        }
    }
}