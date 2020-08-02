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
        static void GetSmallestAndSwap(ref Wetterdaten[] Datensaetze, string value, int start, int anzahl)
        {
            Wetterdaten ergebnis = Datensaetze[start];
            int pos = start;
            for (int index = start + 1; index < anzahl; index++)
            {
                if (compareWetterdatenBy(ergebnis, Datensaetze[index], value) > 0)
                {
                    pos = index;
                }
                else
                {
                }
            }

            tauschen(ref Datensaetze, start, pos);
        }
    }
}