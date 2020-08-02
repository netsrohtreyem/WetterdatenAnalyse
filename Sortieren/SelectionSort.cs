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
        static void SelectionSort(ref Wetterdaten[] Datensaetze, string value, bool aufwaerts)
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

            int index = 0;
            if (aufwaerts)
            {
                do
                {
                    GetSmallestAndSwap(ref Datensaetze, value, index, anzahl);
                    index++;
                } while (index < (anzahl - 1));
            }
            else
            {
                do
                {
                    GetGreatestAndSwap(ref Datensaetze, value, index, anzahl);
                    index++;
                } while (index < (anzahl - 1));
            }
        }
    }
}