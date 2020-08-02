//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WetterdatenAnalyse2020.Properties;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static Wetterdaten DatenSuchen(int art, ref Wetterdaten[] Datensaetze, string value, ref int position)
        {
            Wetterdaten ergebnis = new Wetterdaten(); //leerer Datensatz
            //Wert validieren
            bool validdate = false;
            bool validtemp = false;
            bool validpressure = false;
            bool validfeuchte = false;

            #region Daten korrekt und um was handelt es sich (Datum,Temperatur,Luftdruck oder Luftfeuchtigkeit?
            Regex Vorgabe = new Regex(@"\d{1,2}.\d{1,2}.\d{2,4}");
            Match erg = Vorgabe.Match(value);
            if (erg.Success)
            {
                DateTime tmpdate;
                if (DateTime.TryParse(erg.Value, out tmpdate))
                {
                    //gültige Datum
                    value = erg.Value;
                    validdate = true;
                }
                else
                {
                    //ungültiges Datum
                    validdate = false;
                }
            }
            else //kein Datum enthalten
            {
                validdate = false;
                //Temperaturwert
                Vorgabe = new Regex(@"\D{1}\d{1,2}[,]{0,1}\d{0,2}");
                erg = Vorgabe.Match(value);
                if (erg.Success)
                {
                    validtemp = true;
                }
                else
                {
                    //kein Temperaturwert vorhanden
                    Vorgabe = new Regex(@"\d{1,4}");
                    erg = Vorgabe.Match(value);
                    if (erg.Success)
                    {
                        //Druck oder Feuchtewert
                        if (erg.Value.Length > 2 && erg.Value[0] != '1')
                        {
                            uint wert = Convert.ToUInt32(erg.Value);
                            if (wert >= 700 && wert <= 1080 && erg.Value == value)
                            {
                                validpressure = true;
                            }
                            else
                            {
                                validpressure = false;
                            }
                        }
                        else
                        {
                            uint wert = Convert.ToUInt32(erg.Value);
                            if (wert >= 0 && wert <= 100 && erg.Value == value)
                            {
                                validfeuchte = true;
                            }
                            else
                            {
                                validfeuchte = false;
                            }
                        }
                    }
                    else
                    {
                        //Fehler
                    }
                }
            }

            if (!validdate && !validtemp && !validpressure && !validfeuchte)
            {
                return ergebnis;
            }
            else
            { }
            #endregion

            #region Suche beginnen

            int anzahl = 0;

            //vorhandene Datensätze Zählen
            for (int index = 0; index < Datensaetze.Length; index++)
            {
                if (Datensaetze[index].Luftdruck >= 700)
                {
                    anzahl++;
                }
                else
                { }
            }
            //Sind welche vorhanden?
            if (anzahl <= 0)
            {
                return ergebnis;
            }
            else
            { }

            //Wenn ja, dann 'value' suchen 
            switch (art)
            {
                case 1://Lineares Suchen
                    for (int index = 0; index < anzahl; index++)
                    {
                        if (validdate)
                        {
                            string d1 = Convert.ToDateTime(Datensaetze[index].Datum).ToShortDateString();
                            string d2 = Convert.ToDateTime(value).ToShortDateString();
                            if (d1 == d2)
                            {
                                ergebnis = Datensaetze[index];
                                position = index + 1;
                                break;
                            }
                            else
                            { }
                        }
                        else if (validtemp)
                        {
                            double t1 = Convert.ToDouble(Datensaetze[index].Temperatur);
                            double t2 = Convert.ToDouble(value);
                            if (t1 == t2)
                            {
                                ergebnis = Datensaetze[index];
                                position = index + 1;
                                break;
                            }
                            else
                            { }
                        }
                        else if (validpressure)
                        {
                            uint p1 = Convert.ToUInt32(Datensaetze[index].Luftdruck);
                            uint p2 = Convert.ToUInt32(value);
                            if (p1 == p2)
                            {
                                ergebnis = Datensaetze[index];
                                position = index + 1;
                                break;
                            }
                            else
                            { }
                        }
                        else if (validfeuchte)
                        {
                            uint f1 = Convert.ToUInt32(Datensaetze[index].Luftfeuchtigkeit);
                            uint f2 = Convert.ToUInt32(value);
                            if (f1 == f2)
                            {
                                ergebnis = Datensaetze[index];
                                position = index + 1;
                                break;
                            }
                            else
                            { }
                        }
                        else
                        {
                            //FEhler
                        }
                    }
                    break;
                case 2: //binäres Suchen
                    //erst Sortieren dann suchen
                    if (validdate)
                    {
                        DatenSortieren(1, ref Datensaetze, "Datum", true);

                        int pivot = anzahl / 2;
                        int start = 0;
                        int end = anzahl;

                        do
                        {
                            DateTime d1 = Convert.ToDateTime(Datensaetze[pivot].Datum);
                            DateTime d2 = Convert.ToDateTime(value);

                            if (d1 == d2)
                            {
                                ergebnis = Datensaetze[pivot];
                                position = pivot + 1;
                                start = end = 0;
                            }
                            else if (d1 > d2)
                            {
                                start = 0;
                                end = pivot;
                                pivot = end / 2;
                            }
                            else
                            {
                                start = pivot;
                                end = anzahl;
                                pivot = start + (end - start) / 2;
                            }
                        } while ((end - start) != 0);
                    }
                    else if (validtemp)
                    {
                        DatenSortieren(1, ref Datensaetze, "Temperatur", true);

                        int pivot = anzahl / 2;
                        int start = 0;
                        int end = anzahl;

                        do
                        {
                            double t1 = Convert.ToDouble(Datensaetze[pivot].Temperatur);
                            double t2 = Convert.ToDouble(value);

                            if (Math.Abs(t1 - t2) < 1E-05)
                            {
                                ergebnis = Datensaetze[pivot];
                                position = pivot + 1;
                                start = end = 0;
                            }
                            else if (t1 > t2)
                            {
                                start = 0;
                                end = pivot;
                                pivot = end / 2;
                            }
                            else
                            {
                                start = pivot;
                                end = anzahl;
                                pivot = start + (end - start) / 2;
                            }
                        } while ((end - start) != 0);
                    }
                    else if (validpressure)
                    {
                        DatenSortieren(1, ref Datensaetze, "Luftdruck", true); ;

                        int pivot = anzahl / 2;
                        int start = 0;
                        int end = anzahl;

                        do
                        {
                            uint p1 = Convert.ToUInt32(Datensaetze[pivot].Luftdruck);
                            uint p2 = Convert.ToUInt32(value);

                            if (p1 == p2)
                            {
                                ergebnis = Datensaetze[pivot];
                                position = pivot + 1;
                                start = end = 0;
                            }
                            else if (p1 > p2)
                            {
                                start = 0;
                                end = pivot;
                                pivot = end / 2;
                            }
                            else
                            {
                                start = pivot;
                                end = anzahl;
                                pivot = start + (end - start) / 2;
                            }
                        } while ((end - start) != 0);
                    }
                    else if (validfeuchte)
                    {
                        DatenSortieren(1, ref Datensaetze, "Luftfeuchtigkeit", true);

                        int pivot = anzahl / 2;
                        int start = 0;
                        int end = anzahl;

                        do
                        {
                            uint f1 = Convert.ToUInt32(Datensaetze[pivot].Luftfeuchtigkeit);
                            uint f2 = Convert.ToUInt32(value);

                            if (f1 == f2)
                            {
                                ergebnis = Datensaetze[pivot];
                                position = pivot + 1;
                                start = end = 0;
                            }
                            else if (f1 > f2)
                            {
                                start = 0;
                                end = pivot;
                                pivot = end / 2;
                            }
                            else
                            {
                                start = pivot;
                                end = anzahl;
                                pivot = start + (end - start) / 2;
                            }
                        } while ((end - start) != 0);
                    }
                    else
                    { }
                    break;
                default:
                    break;
            }
            #endregion

            return ergebnis;
        }
    }
}