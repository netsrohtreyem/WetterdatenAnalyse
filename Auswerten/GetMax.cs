//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
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
        static string GetMax(Wetterdaten[] datensaetze, string v, int anzahl, ref int index)
        {
            string ergebnis = "";
            double wdtemp = -100;
            uint wdluftdr = 0;
            uint wdluftf = 0;
            int zaehler = 0;
            for (int index1 = 0; index1 < anzahl; index1++)
            {
                switch (v)
                {
                    case "Temperatur":
                        if (datensaetze[index1].Temperatur > wdtemp)
                        {
                            wdtemp = datensaetze[index1].Temperatur;
                            index = zaehler;
                        }
                        else
                        { }
                        break;
                    case "Luftdruck":
                        if (datensaetze[index1].Luftdruck > wdluftdr)
                        {
                            wdluftdr = datensaetze[index1].Luftdruck;
                            index = zaehler;
                        }
                        else
                        { }
                        break;
                    case "Luftfeuchtigkeit":
                        if (datensaetze[index1].Luftfeuchtigkeit > wdluftf)
                        {
                            wdluftf = datensaetze[index1].Luftfeuchtigkeit;
                            index = zaehler;
                        }
                        else
                        { }
                        break;
                    default:
                        break;
                }
                zaehler++;
            }
            if (wdtemp > -100)
            {
                ergebnis = wdtemp.ToString("F2");
            }
            else if (wdluftdr > 0)
            {
                ergebnis = wdluftdr.ToString();
            }
            else if (wdluftf >= 0)
            {
                ergebnis = wdluftf.ToString();
            }
            else
            {
                ergebnis = "";
            }
            return ergebnis;
        }
    }
}