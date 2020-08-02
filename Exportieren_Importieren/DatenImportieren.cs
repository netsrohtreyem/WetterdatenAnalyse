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
        static bool DatenImportieren(ref Wetterdaten[] Datensaetze, string Pfad, string name, ref int anzahlneue)
        {
            bool ok = false;
            int anzahl = 0;
            //zählen
            foreach (Wetterdaten wd in Datensaetze)
            {
                if (wd.Luftdruck > 700)
                {
                    anzahl++;
                }
                else
                { }
            }

            Wetterdaten[] neu = new Wetterdaten[366];
            FileStream FS = new FileStream(Pfad + "\\" + name, FileMode.Open, FileAccess.Read);

            StreamReader SR = new StreamReader(FS, Encoding.UTF8);

            //Titelzeile
            string input = SR.ReadLine();
            if (!input.Contains("Datum"))
            {
                ok = false;
            }
            else
            {
                int index = 0;
                string tempinput = "";
                while (!SR.EndOfStream)
                {
                    tempinput = SR.ReadLine();
                    string Datum = tempinput.Substring(0, tempinput.IndexOf(";"));
                    tempinput = tempinput.Substring(tempinput.IndexOf(";") + 1);
                    string Temperatur = tempinput.Substring(0, tempinput.IndexOf(";"));
                    tempinput = tempinput.Substring(tempinput.IndexOf(";") + 1);
                    string Luftdruck = tempinput.Substring(0, tempinput.IndexOf(";"));
                    tempinput = tempinput.Substring(tempinput.IndexOf(";") + 1);
                    string Luftfeuchtigkeit = tempinput.Substring(0);
                    tempinput = tempinput.Substring(tempinput.IndexOf(";") + 1);

                    neu[index].Datum = Datum;
                    neu[index].Temperatur = Convert.ToDouble(Temperatur);
                    neu[index].Luftdruck = Convert.ToUInt32(Luftdruck);
                    neu[index].Luftfeuchtigkeit = Convert.ToUInt32(Luftfeuchtigkeit);
                    index++;
                }
                if (index > 0)
                {
                    ok = true;
                    //Überschreiben oder anhängen?
                    Console.CursorVisible = false;
                    Console.WriteLine("\nEs sind " + index + " Datensätze zum Import vorhanden!");
                    Console.Write("\nWollen Sie die vorhandenen " + anzahl + " Datensätze \n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(U)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("eberschreiben oder\n\nDie Datensätze \n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(A)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("nhängen?\n\nAbbrechen mit ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("(ESC)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.CursorVisible = true;
                    while (!Console.KeyAvailable) ;
                    ConsoleKeyInfo inputconsole = Console.ReadKey(true);
                    Console.CursorVisible = false;

                    if (inputconsole.Key == ConsoleKey.Escape)
                    {
                        ok = false;
                    }
                    else if (inputconsole.Key == ConsoleKey.U)
                    {
                        ok = true;
                        Datensaetze = new Wetterdaten[366];
                        if (index < 367)
                        {
                            anzahlneue = index;
                            for (int index2 = 0; index2 < index; index2++)
                            {
                                Datensaetze[index2] = neu[index2];
                            }
                            ok = true;
                        }
                        else
                        {
                            Console.WriteLine("\nEs können nur 366 Datensätze von importiert werden! j/n?");
                            while (!Console.KeyAvailable) ;
                            inputconsole = Console.ReadKey(true);
                            if (inputconsole.Key == ConsoleKey.J)
                            {
                                anzahlneue = 366;
                                if (anzahlneue > index)
                                {
                                    anzahlneue = index;
                                }
                                else
                                { }

                                for (int index2 = 0; index2 < anzahlneue; index2++)
                                {
                                    Datensaetze[index2] = neu[index2];
                                }
                                ok = true;
                            }
                            else
                            {
                                ok = false;
                            }
                        }
                    }
                    else if (inputconsole.Key == ConsoleKey.A)
                    {
                        ok = true;
                        if (anzahl >= 366)
                        {
                            Console.WriteLine("Es können keine weiteren Daten angehängt werden!");
                            Console.WriteLine("Weiter mit einer beliebigen Taste!");
                            while (!Console.KeyAvailable) ;
                            Console.ReadKey(true);
                            ok = false;
                        }
                        else
                        {
                            if ((366 - anzahl - index) < 0)
                            {
                                Console.WriteLine("\nEs können nur " + (366 - anzahl) + " Datensätze von " + index + " angehängt werden! j/n?");
                                while (!Console.KeyAvailable) ;
                                inputconsole = Console.ReadKey(true);
                                if (inputconsole.Key == ConsoleKey.J)
                                {
                                    anzahlneue = (366 - anzahl);
                                    if (anzahlneue > index)
                                    {
                                        anzahlneue = index;
                                    }
                                    else
                                    { }
                                    int doppler = 0;
                                    for (int index2 = 0; index2 < anzahlneue; index2++)
                                    {
                                        int pos = -1;
                                        //Doppler prüfen
                                        if (!isDatensatzVorhanden(Datensaetze, neu[index2], ref pos))
                                        {
                                            Datensaetze[anzahl + index2] = neu[index2];
                                        }
                                        else
                                        {
                                            doppler++;
                                            Console.Clear();
                                            Console.WriteLine("Datensatz vorhanden:\n");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Datum: " + Datensaetze[pos].Datum);
                                            Console.WriteLine("Temperatur: " + Datensaetze[pos].Temperatur.ToString("F2"));
                                            Console.WriteLine("Luftdruck: " + Datensaetze[pos].Luftdruck.ToString());
                                            Console.WriteLine("Luftfeuchtigkeit: " + Datensaetze[pos].Luftfeuchtigkeit.ToString());
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine("\nersetzen durch:\n");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Datum: " + neu[index2].Datum);
                                            Console.WriteLine("Temperatur: " + neu[index2].Temperatur.ToString("F2"));
                                            Console.WriteLine("Luftdruck: " + neu[index2].Luftdruck.ToString());
                                            Console.WriteLine("Luftfeuchtigkeit: " + neu[index2].Luftfeuchtigkeit.ToString());
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine("\n(j/n)?");
                                            while (!Console.KeyAvailable) ;
                                            inputconsole = Console.ReadKey(true);
                                            if (inputconsole.Key == ConsoleKey.J)
                                            {
                                                Datensaetze[pos] = neu[index2];
                                            }
                                            else
                                            {

                                            }
                                            anzahlneue--;
                                        }
                                    }

                                    ok = true;
                                }
                                else
                                {
                                    ok = false;
                                }
                            }
                            else
                            {
                                anzahlneue = index;
                                int doppler = 0;
                                int pos = -1;
                                for (int index2 = 0; index2 < index; index2++)
                                {
                                    //Doppler prüfen
                                    if (!isDatensatzVorhanden(Datensaetze, neu[index2], ref pos))
                                    {
                                        Datensaetze[anzahl + index2] = neu[index2];
                                    }
                                    else
                                    {
                                        doppler++;
                                        Console.Clear();
                                        Console.WriteLine("Datensatz vorhanden:\n");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("Datum: " + Datensaetze[pos].Datum);
                                        Console.WriteLine("Temperatur: " + Datensaetze[pos].Temperatur.ToString("F2"));
                                        Console.WriteLine("Luftdruck: " + Datensaetze[pos].Luftdruck.ToString());
                                        Console.WriteLine("Luftfeuchtigkeit: " + Datensaetze[pos].Luftfeuchtigkeit.ToString());
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine("\nersetzen durch:\n");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("Datum: " + neu[index2].Datum);
                                        Console.WriteLine("Temperatur: " + neu[index2].Temperatur.ToString("F2"));
                                        Console.WriteLine("Luftdruck: " + neu[index2].Luftdruck.ToString());
                                        Console.WriteLine("Luftfeuchtigkeit: " + neu[index2].Luftfeuchtigkeit.ToString());
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine("\n(j/n)?");

                                        while (!Console.KeyAvailable) ;
                                        inputconsole = Console.ReadKey(true);

                                        if (inputconsole.Key == ConsoleKey.J)
                                        {
                                            Datensaetze[pos] = neu[index2];
                                        }
                                        else
                                        {
                                        }
                                        anzahlneue--;
                                    }
                                }
                                ok = true;
                            }
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }
            SR.Close();
            FS.Close();
            return ok;
        }
    }
}