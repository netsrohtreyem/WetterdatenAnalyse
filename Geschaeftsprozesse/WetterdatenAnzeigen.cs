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
        static void WetterdatenAnzeigen(Wetterdaten[] Datensaetze, int seite)
        {
            //seite: 1-n oder -1 für alles
            Console.Clear();
            int anzahl = 0;
            int nummer = 1;
            //Zählen
            foreach (Wetterdaten wd in Datensaetze)
            {
                if (wd.Luftdruck >= 700)
                {
                    anzahl++;
                }
                else
                { }
            }
            //Anzahl anzeigen
            if (anzahl > 1)
            {
                Console.WriteLine("Es sind insgesamt " + anzahl + " Datensätze vorhanden");
            }
            else
            {
                Console.WriteLine("Es ist " + anzahl + " Datensatz vorhanden");
            }
            //Tabelle anzeigen
            //1. Kopfzeile
            string format = "│{0,-5}│{1,-16}│{2,-15}│{3,-15}│{4,-20}│";
            Console.WriteLine("┌─────┬────────────────┬───────────────┬───────────────┬────────────────────┐");
            Console.WriteLine(format, "Nr.", "Datum", "Temperatur [°C]", "Luftdruck [hPa]", "Luftfeuchtigkeit [%]");
            Console.WriteLine("├─────┼────────────────┼───────────────┼───────────────┼────────────────────┤");
            if (anzahl <= 0)
            {
                Console.WriteLine(format, "", "", "", "", "");
            }
            else
            {
                //2.Mittelteil
                int grenze = (15 * (seite - 1)) + 15;
                if (grenze > 366)
                {
                    grenze = 366;
                }
                else
                { }

                for (nummer = (15 * (seite - 1)); nummer < grenze; nummer++)
                {
                    if (Datensaetze[nummer].Luftdruck <= 0)
                    {
                        break;
                    }
                    else
                    {
                        //F2: double mit zwei Nachkommastellen
                        Console.WriteLine(format, nummer + 1, Datensaetze[nummer].Datum, Datensaetze[nummer].Temperatur.ToString("F2"), Datensaetze[nummer].Luftdruck.ToString(), Datensaetze[nummer].Luftfeuchtigkeit.ToString()); ;
                    }
                }
            }
            //3.Fussteil
            Console.WriteLine("└─────┴────────────────┴───────────────┴───────────────┴────────────────────┘");
        }

        static void WetterdatenAnzeigen(Wetterdaten[] Datensaetze)
        {
            int index = 1;
            bool fertig = false;
            int anzahl = 0;

            //Zählen
            foreach (Wetterdaten wd in Datensaetze)
            {
                if (wd.Luftdruck >= 700)
                {
                    anzahl++;
                }
                else
                { }
            }


            //Daten anzeigen
            ConsoleKeyInfo input;
            do
            {

                WetterdatenAnzeigen(Datensaetze, index);

                //Menü
                if ((anzahl % 15) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<-");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Seite zurück    (Seite " + index + " von " + (anzahl / 18 + 1) + ")     ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" zurück           Seite weiter ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<-");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Seite zurück    (Seite " + index + " von " + (anzahl / 18) + ")     ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(ESC)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" zurück           Seite weiter ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //Sortieren und Suchen
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("             (F) ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Datensatz finden          ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(S) ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Datensätze sortieren\n");

                //Auswerten
                while (!Console.KeyAvailable) ;
                input = Console.ReadKey(true);

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
                    if (anzahl > 15 && index <= (anzahl / 15))
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
                else if (input.Key == ConsoleKey.F)
                {
                    if (anzahl <= 0)
                    {
                        continue;
                    }
                    else
                    { }
                    Console.CursorTop = Console.CursorTop - 2;
                    Console.Write("                                                                                                  \n");
                    Console.CursorTop = Console.CursorTop - 1;
                    Console.Write("                                                                                                  \n");
                    Console.CursorTop = Console.CursorTop - 3;
                    bool ok = false;
                    Wetterdaten ergebnis = new Wetterdaten();
                    int position = 0;
                    string eingabe;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("      (L)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("ineares Suchen           ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(B)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("inäres Suchen       ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(ESC) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("zurück");

                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.L)
                        {
                            Console.CursorVisible = true;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Lineares Suchen                                                         ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Geben Sie den zu suchenden Wert ein:");
                            Console.Write("Format: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Datum");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (tt.mm.jjjj), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Temperatur (°C)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (vv,nn), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Luftdruck (hPa)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (dddd), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nLuftfeuchtigkeit (%)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (fff))\n");
                            Console.Write("(Eingabe mit ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("return ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("bestätigen oder ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("abbrechen: return");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" drücken)\n");
                            eingabe = Console.ReadLine();
                            Console.CursorVisible = false;

                            if (eingabe == "")
                            {
                                break;
                            }
                            else
                            { }

                            ergebnis = DatenSuchen(1, ref Datensaetze, eingabe, ref position);
                        }
                        else if (input.Key == ConsoleKey.B)
                        {
                            Console.CursorVisible = true;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Binäres Suchen                                                         ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Geben Sie den zu suchenden Wert ein:");
                            Console.Write("Format: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Datum");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (tt.mm.jjjj), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Temperatur (°C)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (vv,nn), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Luftdruck (hPa)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (dddd), ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nLuftfeuchtigkeit (%)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" (fff))\n");
                            Console.Write("(Eingabe mit ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("return ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("bestätigen oder ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("abbrechen: return");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" drücken)\n");
                            eingabe = Console.ReadLine();
                            Console.CursorVisible = false;

                            if (eingabe == "")
                            {
                                break;
                            }
                            else
                            { }

                            position = 0;

                            ergebnis = DatenSuchen(2, ref Datensaetze, eingabe, ref position);
                        }
                        else if (input.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else
                        {
                            Console.CursorLeft = 0;
                            Console.Write("                                                                                 ");
                            Console.CursorLeft = 0;
                            Console.CursorTop = Console.CursorTop - 1;
                            ok = false;
                            continue;
                        }

                        if (ergebnis.Luftdruck >= 700)
                        {
                            string format = "{0,-18}{1,-12}";
                            Console.WriteLine("\nGefundener Datensatz\n");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Nr.");
                            Console.Write((position) + " :\n");

                            Console.WriteLine(format, "Datum: ", Datensaetze[position - 1].Datum);
                            Console.WriteLine(format, "Temperatur: ", Datensaetze[position - 1].Temperatur.ToString("F2") + " °C");
                            Console.WriteLine(format, "Luftdruck: ", Datensaetze[position - 1].Luftdruck + " hPa");
                            Console.WriteLine(format, "Luftfeuchtigkeit: ", Datensaetze[position - 1].Luftfeuchtigkeit + " %\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Der Text \"" + eingabe + "\" wurde nicht gefunden!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWeiter mit einer beliebigen Taste!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        while (!Console.KeyAvailable) ;
                        Console.ReadKey(true);
                        ok = true;
                    } while (!ok);
                }
                else if (input.Key == ConsoleKey.S)
                {
                    if (anzahl <= 0)
                    {
                        continue;
                    }
                    else
                    { }
                    Console.CursorTop = Console.CursorTop - 2;
                    Console.Write("                                                                                                  \n");
                    Console.CursorTop = Console.CursorTop - 1;
                    Console.Write("                                                                                                  \n");
                    Console.CursorTop = Console.CursorTop - 3;
                    bool ok = false;
                    bool aufwaerts = true;
                    string eingabe = "";
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("      (B)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("ubble Sort           ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(S)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("election Sort       ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("(ESC) ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("zurück");

                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.B)
                        {
                            Console.CursorVisible = false;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Bubble Sort                                                         ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Wonach soll sortiert werden?");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(D)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("atum, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(T)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("emperatur, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(L)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("uftdruck, Luft");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(F)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("euchtigkeit, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(ESC)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" zurück\n");

                            while (!Console.KeyAvailable) ;
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.D)
                            {
                                eingabe = "Datum";
                            }
                            else if (input.Key == ConsoleKey.T)
                            {
                                eingabe = "Temperatur";
                            }
                            else if (input.Key == ConsoleKey.L)
                            {
                                eingabe = "Luftdruck";
                            }
                            else if (input.Key == ConsoleKey.F)
                            {
                                eingabe = "Luftfeuchtigkeit";
                            }
                            else if (input.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(A)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("ufwärts oder ab");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(w)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("ärts sortieren? ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(ESC)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" zurück");
                            while (!Console.KeyAvailable) ;
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.A)
                            {
                                aufwaerts = true;
                            }
                            else if (input.Key == ConsoleKey.W)
                            {
                                aufwaerts = false;
                            }
                            else if (input.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }

                            DatenSortieren(1, ref Datensaetze, eingabe, aufwaerts);

                            ok = true;
                            Console.CursorVisible = false;
                        }
                        else if (input.Key == ConsoleKey.S)
                        {
                            Console.CursorVisible = true;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Selection Sort                                                       ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Wonach soll sortiert werden?\n");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(D)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("atum, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(T)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("emperatur, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(L)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("uftdruck, Luft");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(F)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("euchtigkeit\n");
                            while (!Console.KeyAvailable) ;
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.D)
                            {
                                eingabe = "Datum";
                            }
                            else if (input.Key == ConsoleKey.T)
                            {
                                eingabe = "Temperatur";
                            }
                            else if (input.Key == ConsoleKey.L)
                            {
                                eingabe = "Luftdruck";
                            }
                            else if (input.Key == ConsoleKey.F)
                            {
                                eingabe = "Luftfeuchtigkeit";
                            }
                            else if (input.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(A)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("ufwärts oder ab");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(w)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("ärts sortieren? ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(ESC)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" zurück");
                            while (!Console.KeyAvailable) ;
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.A)
                            {
                                aufwaerts = true;
                            }
                            else if (input.Key == ConsoleKey.W)
                            {
                                aufwaerts = false;
                            }
                            else if (input.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }

                            DatenSortieren(2, ref Datensaetze, eingabe, aufwaerts);

                            ok = true;
                            Console.CursorVisible = false;
                        }
                        else if (input.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else
                        {
                            Console.CursorLeft = 0;
                            Console.Write("                                                                                 ");
                            Console.CursorLeft = 0;
                            Console.CursorTop = Console.CursorTop - 1;
                            ok = false;
                            continue;
                        }
                    } while (!ok);
                }
                else
                {
                    //Fehler
                }
            } while (!fertig);
        }
    }
}