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
        static void DatenSortieren(int art, ref Wetterdaten[] Datensaetze, string value, bool aufwaerts)
        {
            if (art == 1)
            {
                BubbleSort(ref Datensaetze, value, aufwaerts);
            }
            else if (art == 2)
            {
                SelectionSort(ref Datensaetze, value, aufwaerts);
            }
            else
            { }
        }
    }
}