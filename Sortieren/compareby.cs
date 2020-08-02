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
        static int compareWetterdatenBy(Wetterdaten value1, Wetterdaten value2, string value)
        {
            int ergebnis = 0;
            if (value == "Datum")
            {
                ergebnis = Convert.ToDateTime(value1.Datum).CompareTo(Convert.ToDateTime(value2.Datum));
            }
            else if (value == "Temperatur")
            {
                if (Convert.ToDouble(value1.Temperatur) > Convert.ToDouble(value2.Temperatur))
                {
                    ergebnis = 1;
                }
                else if (Convert.ToDouble(value1.Temperatur) < Convert.ToDouble(value2.Temperatur))
                {
                    ergebnis = -1;
                }
                else
                {
                    ergebnis = 0;
                }
            }
            else if (value == "Luftdruck")
            {
                if (Convert.ToUInt32(value1.Luftdruck) > Convert.ToUInt32(value2.Luftdruck))
                {
                    ergebnis = 1;
                }
                else if (Convert.ToUInt32(value1.Luftdruck) < Convert.ToUInt32(value2.Luftdruck))
                {
                    ergebnis = -1;
                }
                else
                {
                    ergebnis = 0;
                }
            }
            else if (value == "Luftfeuchtigkeit")
            {
                if (Convert.ToUInt32(value1.Luftfeuchtigkeit) > Convert.ToUInt32(value2.Luftfeuchtigkeit))
                {
                    ergebnis = 1;
                }
                else if (Convert.ToUInt32(value1.Luftfeuchtigkeit) < Convert.ToUInt32(value2.Luftfeuchtigkeit))
                {
                    ergebnis = -1;
                }
                else
                {
                    ergebnis = 0;
                }
            }
            else
            { }
            return ergebnis;
        }
    }
}