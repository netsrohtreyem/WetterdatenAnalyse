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
        static bool isDatensatzVorhanden(Wetterdaten[] datensaetze, Wetterdaten doppler, ref int pos)
        {
            bool ergebnis = false;
            int index = 0;
            foreach (Wetterdaten wd in datensaetze)
            {
                if (wd.Datum == doppler.Datum)
                {
                    ergebnis = true;
                    pos = index;
                    break;
                }
                else
                {
                    ergebnis = false;
                }
                index++;
            }

            return ergebnis;
        }
    }
}