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
        static void WetterdatenLoeschen(ref Wetterdaten[] Datensaetze)
        {
            int index = 1;
            int anzahl = 0;

            ConsoleKeyInfo input;
            bool fertig = false;



            while (!fertig)
            {
                int rangevon = -1;
                int rangebis = -1;
                //Zählen
                anzahl = 0;
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
                    Console.WriteLine("\nKeine Datensätze zum Löschen vorhanden!");
                    Console.WriteLine("Weiter mit einer beliebigen Taste!");
                    while (!Console.KeyAvailable) ;
                    Console.ReadKey(true);
                    return;
                }
                else
                { }

                WetterdatenAnzeigen(Datensaetze, index);

                //Steuerung anzeigen
                if ((anzahl % 18) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<-");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Seite zurück (Seite " + index + " von " + (anzahl / 18 + 1) + ") ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(L)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Loeschen  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" zurück  Seite weiter ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<-");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Seite zurück (Seite " + index + " von " + (anzahl / 18) + ") ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(L)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Loeschen  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" zurück  Seite weiter ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }


                while (!Console.KeyAvailable) ;
                input = Console.ReadKey(true);

                //Tasten Auswerten
                if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (index > 1)
                    {
                        index--;
                    }
                    else
                    { }
                    continue;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    if (anzahl > 18 && index <= (anzahl / 18))
                    {
                        index++;
                    }
                    else
                    { }
                    continue;
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (input.KeyChar == 'L' || input.KeyChar == 'l')
                {
                    //Position erfragen
                    int pos = -1;
                    Console.Write("\nGeben Sie die ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Nr. ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("des Datensatzes ein den Sie löschen wollen,\n");
                    Console.Write("oder einen ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Bereich ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("(z.B. 2-5): ");
                    Console.CursorVisible = true;
                    string eingabe = Console.ReadLine();
                    //Range?
                    if (eingabe.Contains("-"))
                    {
                        //Eingabe prüfen
                        try
                        {
                            string temp = eingabe.Substring(0, eingabe.IndexOf("-"));
                            rangevon = Convert.ToInt32(temp);
                            if (rangevon < 1)
                            {
                                rangevon = -1;
                            }
                            else
                            { }
                            temp = eingabe.Substring(eingabe.IndexOf("-") + 1);
                            rangebis = Convert.ToInt32(temp);
                            if (rangebis > anzahl)
                            {
                                rangebis = -1;
                            }
                            else
                            { }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNur gültige Zeichen eingeben, Format: z.B. 2-5!\nWeiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            continue;
                        }
                        //Range prüfen
                        if (rangevon < 0 || rangebis < 0 || rangevon > anzahl || rangebis > anzahl)
                        {
                            Console.WriteLine("\nDer Bereich ist ungültig, es sind nur die Positionen 1 bis " + anzahl + " verfügbar!");
                            Console.WriteLine("Weiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            continue;
                        }
                        else
                        { }
                    }
                    //Einzelner Wert?
                    else
                    {
                        //Eingabe prüfen
                        try
                        {
                            pos = Convert.ToInt32(eingabe);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNur gültige Zeichen eingeben! Weiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            continue;
                        }
                        //Falsche Position gewählt
                        if (pos > anzahl || pos < 1)
                        {
                            Console.WriteLine("Ausgewählter Datensatz ungültig, es sind nur die Positionen 1 bis " + anzahl + " verfügbar!");
                            Console.WriteLine("Weiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey();
                            continue;
                        }
                        else
                        { }
                    }

                    //einzelne Werte löschen
                    if (pos > 0)
                    {
                        Console.Clear();
                        Console.Write("Ausgewählter Datensatz: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nr." + pos + " , vom " + Datensaetze[pos - 1].Datum);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n(Wert löschen mit 'return' oder abbrechen mit 'ESC')\n");
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Escape)
                        {
                            continue;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            Wetterdaten[] neu = new Wetterdaten[366];
                            //Löschen
                            for (int index1 = 0; index1 < pos - 1; index1++)
                            {
                                neu[index1] = Datensaetze[index1];
                            }
                            for (int index1 = pos; index1 < anzahl; index1++)
                            {
                                neu[index1 - 1] = Datensaetze[index1];
                            }
                            Datensaetze = neu;
                        }
                        else
                        {

                        }
                    }
                    else //Range löschen
                    {
                        Console.Clear();
                        Console.Write("Ausgewählte Datensätze: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nr." + rangevon + " bis Nr. " + rangebis);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n(Werte löschen mit 'return' oder abbrechen mit 'ESC')\n");
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Escape)
                        {
                            continue;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            Wetterdaten[] neu = new Wetterdaten[366];
                            //Löschen
                            int index1 = 0;
                            int index2 = 0;
                            for (index1 = 0; index1 < rangevon - 1; index1++)
                            {
                                neu[index1] = Datensaetze[index1];
                            }
                            for (index2 = rangebis; index2 < anzahl; index2++)
                            {
                                neu[index1] = Datensaetze[index2];
                                index1++;
                            }
                            Datensaetze = neu;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    //Fehler
                }
            }
        }
    }
}