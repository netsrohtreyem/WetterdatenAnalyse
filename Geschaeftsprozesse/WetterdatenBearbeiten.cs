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
        static void WetterdatenBearbeiten(ref Wetterdaten[] Datensaetze)
        {
            int index = 1;
            bool fertig = false;
            int anzahl = 0;
            ConsoleKeyInfo input;
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
                if (anzahl <= 0)
                {
                    Console.WriteLine("\nKeine Datensätze zur Bearbeitung vorhanden!");
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
                    Console.Write("(B)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Bearbeiten  ");
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
                    Console.Write("(B)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Bearbeiten  ");
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
                else if (input.KeyChar == 'B' || input.KeyChar == 'b')
                {
                    //Position erfragen
                    int pos = -1;

                    Console.Write("\nGeben Sie die Nr. des Datensatzes ein den Sie bearbeiten wollen: ");

                    try
                    {
                        pos = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                    }

                    if (pos > anzahl || pos < 1)
                    {
                        continue;
                    }
                    else
                    { }
                    Console.Clear();
                    Console.Write("Ausgewählter Datensatz: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nr." + pos + " , vom " + Datensaetze[pos - 1].Datum);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n(Wert übernehmen mit 'return' oder ändern und\n anschliessend mit 'return' bestätigen)\n");
                    int anzahlziffern = 0;
                    double tempwert = 0;
                    uint druckwert = 0;
                    uint feuchtewert = 0;
                    bool ok = false;
                    string inputstring = "";
                    Console.CursorVisible = true;

                    #region Temperatur
                    Console.WriteLine("Temperatur (-50°C <-> +60°C):");

                    int laenge = Datensaetze[pos - 1].Temperatur.ToString("F2").Length;

                    if (!(Datensaetze[pos - 1].Temperatur.ToString().Contains("-") ||
                         Datensaetze[pos - 1].Temperatur.ToString().Contains("+")))
                    {
                        if (Datensaetze[pos - 1].Temperatur.ToString().Contains(",") ||
                            Datensaetze[pos - 1].Temperatur.ToString().Contains("."))
                        {
                            laenge -= 1;
                        }
                        else
                        { }

                        string ausgabe = " °C";
                        Console.Write(Datensaetze[pos - 1].Temperatur.ToString("F2") + ausgabe);
                        if (Datensaetze[pos - 1].Temperatur.ToString().Contains(",") ||
                            Datensaetze[pos - 1].Temperatur.ToString().Contains("."))
                        {
                            Console.CursorLeft = laenge + 1;
                        }
                        else
                        {
                            Console.CursorLeft = laenge;
                        }
                    }
                    else
                    {
                        if (Datensaetze[pos - 1].Temperatur.ToString().Contains(",") ||
                            Datensaetze[pos - 1].Temperatur.ToString().Contains("."))
                        {
                            laenge -= 1;
                        }
                        else
                        { }

                        string ausgabe = " °C";
                        Console.Write(Datensaetze[pos - 1].Temperatur.ToString("F2") + ausgabe);
                        if (Datensaetze[pos - 1].Temperatur.ToString().Contains(",") ||
                            Datensaetze[pos - 1].Temperatur.ToString().Contains("."))
                        {
                            Console.CursorLeft = laenge + 1;
                        }
                        else
                        {
                            Console.CursorLeft = laenge;
                        }
                    }

                    anzahlziffern = Datensaetze[pos - 1].Temperatur.ToString("F2").Length;

                    tempwert = 0;
                    ok = false;
                    inputstring = Datensaetze[pos - 1].Temperatur.ToString("F2");
                    do
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Backspace)
                        {
                            if (anzahlziffern > 0)
                            {
                                Console.CursorLeft = Console.CursorLeft - 1;
                                Console.Write(" ");
                                Console.CursorLeft = Console.CursorLeft - 1;
                                anzahlziffern--;
                            }
                            else
                            { }
                            if (inputstring.Length > 0)
                            {
                                inputstring = inputstring.Remove(inputstring.Length - 1, 1);
                            }
                            else
                            { }
                        }
                        else if (input.Key == ConsoleKey.Escape)
                        {
                            Console.CursorVisible = false;
                            return;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            if (inputstring != "")
                            {
                                tempwert = Convert.ToDouble(inputstring);
                                if (tempwert < -50 || tempwert > 60)
                                {
                                    inputstring = "";
                                    anzahlziffern = 0;
                                    Console.CursorLeft = 0;
                                    Console.Write("      °C");
                                    Console.CursorLeft = 0;
                                    ok = false;
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    ok = true;
                                }
                            }
                            else
                            { }
                            continue;
                        }
                        else if (input.KeyChar >= '0' &&
                                 input.KeyChar <= '9' &&
                                 (((inputstring.Contains(",") || inputstring.Contains(".")) && anzahlziffern < 5) ||
                                  (!(inputstring.Contains(",") || inputstring.Contains(".")) && anzahlziffern < 4) ||
                                 ((inputstring.Contains("+") || inputstring.Contains("-")) && anzahlziffern < 6)))
                        {
                            inputstring += input.KeyChar;
                            Console.Write(input.KeyChar);
                            anzahlziffern++;
                        }
                        else if (input.KeyChar == ',' || input.KeyChar == '.')
                        {
                            inputstring += input.KeyChar;
                            Console.Write(input.KeyChar);
                            anzahlziffern++;
                        }
                        else if ((input.KeyChar == '-' || input.KeyChar == '+') && anzahlziffern == 0)
                        {
                            for (int index2 = 0; index2 <= laenge + 1; index2++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(" °C");
                            Console.CursorLeft = 0;
                            inputstring += input.KeyChar;
                            Console.Write(input.KeyChar);
                            anzahlziffern++;
                        }
                        else
                        {

                        }
                    } while (!ok || inputstring == "");

                    Datensaetze[pos - 1].Temperatur = tempwert;
                    #endregion
                    Console.WriteLine();
                    #region Luftdruck
                    Console.CursorVisible = true;
                    Console.WriteLine("Luftdruck (700 hPa <-> 1080 hPA):");
                    Console.Write(Datensaetze[pos - 1].Luftdruck + "  hPa");
                    Console.CursorLeft = Console.CursorLeft - 5;
                    anzahlziffern = Datensaetze[pos - 1].Luftdruck.ToString().Length;
                    druckwert = 0;
                    ok = false;
                    inputstring = Datensaetze[pos - 1].Luftdruck.ToString();
                    do
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Backspace)
                        {
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                            if (anzahlziffern > 0)
                            {
                                anzahlziffern--;
                            }
                            else
                            { }
                            if (inputstring.Length > 0)
                            {
                                inputstring = inputstring.Remove(inputstring.Length - 1, 1);
                            }
                            else
                            { }
                        }
                        else if (input.Key == ConsoleKey.Escape)
                        {
                            Console.CursorVisible = false;
                            return;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            if (inputstring != "")
                            {
                                druckwert = Convert.ToUInt32(inputstring);
                                if (druckwert < 700 || druckwert > 1080)
                                {
                                    inputstring = "";
                                    anzahlziffern = 0;
                                    Console.Write("     ");
                                    Console.CursorLeft = 0;
                                    ok = false;
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    ok = true;
                                }
                            }
                            else
                            { }
                            continue;
                        }
                        else if (input.KeyChar >= '0' && input.KeyChar <= '9' && anzahlziffern < 4)
                        {
                            inputstring += input.KeyChar;
                            anzahlziffern++;
                        }
                        else
                        {
                            Console.CursorLeft = Console.CursorLeft - 1;
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                        }
                    } while (!ok || inputstring == "");

                    Datensaetze[pos - 1].Luftdruck = druckwert;
                    #endregion
                    Console.WriteLine();
                    #region Luftfeuchtigkeit
                    Console.CursorVisible = true;
                    Console.WriteLine("Luftfeuchtigkeit (0% <-> 100%):");
                    Console.Write(Datensaetze[pos - 1].Luftfeuchtigkeit + "  %");
                    Console.CursorLeft = Console.CursorLeft - 3;
                    anzahlziffern = Datensaetze[pos - 1].Luftfeuchtigkeit.ToString().Length;
                    druckwert = 0;
                    ok = false;
                    inputstring = Datensaetze[pos - 1].Luftfeuchtigkeit.ToString();
                    do
                    {
                        while (!Console.KeyAvailable) ;
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Backspace)
                        {
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                            if (anzahlziffern > 0)
                            {
                                anzahlziffern--;
                            }
                            else
                            { }
                            if (inputstring.Length > 0)
                            {
                                inputstring = inputstring.Remove(inputstring.Length - 1, 1);
                            }
                            else
                            { }
                        }
                        else if (input.Key == ConsoleKey.Escape)
                        {
                            Console.CursorVisible = false;
                            return;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            if (inputstring != "")
                            {
                                feuchtewert = Convert.ToUInt32(inputstring);
                                if (feuchtewert < 0 || feuchtewert > 100)
                                {
                                    inputstring = "";
                                    anzahlziffern = 0;
                                    Console.Write("    ");
                                    Console.CursorLeft = 0;
                                    ok = false;
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    ok = true;
                                }
                            }
                            else
                            { }
                            continue;
                        }
                        else if (input.KeyChar >= '0' && input.KeyChar <= '9' && anzahlziffern < 3)
                        {
                            inputstring += input.KeyChar;
                            anzahlziffern++;
                        }
                        else
                        {
                            Console.CursorLeft = Console.CursorLeft - 1;
                            Console.Write(" ");
                            Console.CursorLeft = Console.CursorLeft - 1;
                        }
                    } while (!ok || inputstring == "");

                    Datensaetze[pos - 1].Luftfeuchtigkeit = feuchtewert;
                    #endregion
                    fertig = true;
                }
                else
                {
                    //Fehler
                }

            } while (!fertig);
        }
    }
}