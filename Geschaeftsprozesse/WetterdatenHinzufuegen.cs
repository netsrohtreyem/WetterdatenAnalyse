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
        static void WetterdatenHinzufuegen(ref Wetterdaten[] Datensaetze)
        {
            int index = 1;
            bool fertig = false;
            int anzahl = 0;

            do
            {
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

                WetterdatenAnzeigen(Datensaetze, index);

                //Steuerung anzeigen
                Console.CursorVisible = false;
                if ((anzahl % 18) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<-");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Seite zurück (Seite " + index + " von " + (anzahl / 18 + 1) + ") ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(H) ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Hinzufuegen ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC) ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("zurück ");
                    Console.Write("Seite weiter ");
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
                    Console.Write("(H) ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Hinzufuegen ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC) ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("zurück ");
                    Console.Write("Seite weiter ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                while (!Console.KeyAvailable) ;
                ConsoleKeyInfo input = Console.ReadKey(true);

                //Tasten Auswerten
                if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (index > 1)
                    {
                        index--;
                    }
                    else
                    { }
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    if (anzahl > 18 && index <= (anzahl / 18))
                    {
                        index++;
                    }
                    else
                    { }
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    fertig = true;
                }
                else if (input.Key == ConsoleKey.H)
                {
                    //Max Grenze prüfen
                    if (anzahl >= 366)
                    {
                        Console.WriteLine("Die Datenbank ist voll (366 Datensätze vorhanden!)");
                        Console.WriteLine("Weiter mit einer beliebigen Taste");
                        while (!Console.KeyAvailable) ;
                        Console.ReadKey(true);
                        break;
                    }
                    else
                    { }

                    //Dateneinlesen + Position erfragen
                    if (anzahl > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.Write("    (2) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Am Ende Anhängen  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(3) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Nach Nr. einfügen  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(4) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Vor Nr. einfügen");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.Write("    (2) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Am Ende Anhängen  ");
                    }
                    while (!Console.KeyAvailable) ;
                    input = Console.ReadKey(true);
                    if (input.KeyChar == '2')
                    {
                        WetterdatenEinlesen(ref Datensaetze, -1, false); //-1: am Ende
                    }
                    else if (input.KeyChar == '3' && anzahl > 0)
                    {
                        Console.CursorTop = Console.CursorTop - 1;
                        Console.WriteLine("                                                                                 ");
                        Console.CursorTop = Console.CursorTop - 1;
                        Console.Write("Nach welcher Nummer soll eingefügt werden? ");
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(false);
                        if (input.Key == ConsoleKey.Escape)
                        {
                            continue;
                        }
                        else
                        { }
                        int nummer = -1;
                        try
                        {
                            string tmp = Console.ReadLine();
                            nummer = Convert.ToInt32(input.KeyChar + tmp);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Es nur Ziffer erlaubt!");
                        }
                        if (nummer < 1 || nummer > anzahl)
                        {
                            Console.WriteLine("Bitte eine gültige Nummer eingeben, es sind die Datensaetze 1 bis " + anzahl + " vorhanden!");
                            Console.WriteLine("Weiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                        }
                        else
                        {
                            WetterdatenEinlesen(ref Datensaetze, nummer, false);//nummer einfügeposition
                        }
                    }
                    else if (input.KeyChar == '4' && anzahl > 0)
                    {
                        Console.CursorTop = Console.CursorTop - 1;
                        Console.WriteLine("                                                                                  ");
                        Console.CursorTop = Console.CursorTop - 1;
                        Console.Write("Vor welcher Nummer soll eingefügt werden? ");
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(false);
                        if (input.Key == ConsoleKey.Escape)
                        {
                            continue;
                        }
                        else
                        { }
                        int nummer = -1;
                        try
                        {
                            string tmp = Console.ReadLine();
                            nummer = Convert.ToInt32(input.KeyChar + tmp);
                            Console.CursorVisible = true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Es nur Ziffer erlaubt!");
                        }
                        if (nummer < 1 || nummer > anzahl)
                        {
                            Console.WriteLine("Bitte eine gültige Nummer eingeben, es sind die Datensaetze 1 bis " + anzahl + " vorhanden!");
                            Console.WriteLine("Weiter mit einer beliebigen Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                        }
                        else
                        {
                            WetterdatenEinlesen(ref Datensaetze, nummer, true);//nummer einfügeposition
                        }
                    }
                    else if (input.Key == ConsoleKey.LeftArrow)
                    {
                        if (index > 1)
                        {
                            index--;
                        }
                        else
                        { }
                        WetterdatenAnzeigen(Datensaetze, index);
                    }
                    else if (input.Key == ConsoleKey.RightArrow)
                    {
                        if (anzahl > 18 && index <= (anzahl / 18))
                        {
                            index++;
                        }
                        else
                        { }
                        WetterdatenAnzeigen(Datensaetze, index);
                    }
                    else if (input.Key == ConsoleKey.Escape)
                    {
                        continue;
                    }
                    else
                    {
                        if (anzahl > 0)
                        {
                            Console.WriteLine(" Nur (2) - (4) möglich!, weiter mit beliebiger Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine(" Nur (2) möglich!, weiter mit beliebiger Taste");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                        }
                    }
                }
                else
                {
                    //Fehler
                }

            } while (!fertig);
        }
    }
}