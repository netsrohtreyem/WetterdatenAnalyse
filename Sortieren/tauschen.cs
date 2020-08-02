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
        static void tauschen(ref Wetterdaten[] Datensaetze, int index1, int index2)
        {
            Wetterdaten temp = Datensaetze[index1];
            Datensaetze[index1] = Datensaetze[index2];
            Datensaetze[index2] = temp;
        }
    }
}