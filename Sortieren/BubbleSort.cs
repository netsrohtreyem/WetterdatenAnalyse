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
        static void BubbleSort(ref Wetterdaten[] Datensaetze, string value, bool aufwaerts)
        {
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

            if (anzahl <= 0)
            {
                return;
            }
            else
            { }

            if (aufwaerts)
            {
                int index1 = 0;
                int index2 = 0;
                for (index1 = 0; index1 < anzahl - 1; index1++)
                {
                    for (index2 = index1 + 1; index2 < anzahl; index2++)
                    {
                        if (compareWetterdatenBy(Datensaetze[index1], Datensaetze[index2], value) > 0)
                        {
                            tauschen(ref Datensaetze, index1, index2);
                        }
                        else
                        { }
                    }
                }
            }
            else
            {
                int index1 = 0;
                int index2 = 0;
                for (index1 = 0; index1 < anzahl - 1; index1++)
                {
                    for (index2 = index1 + 1; index2 < anzahl; index2++)
                    {
                        if (compareWetterdatenBy(Datensaetze[index1], Datensaetze[index2], value) < 0)
                        {
                            tauschen(ref Datensaetze, index1, index2);
                        }
                        else
                        { }
                    }
                }
            }
        }
    }
}