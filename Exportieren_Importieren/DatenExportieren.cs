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
        static void DatenExportieren(Wetterdaten[] Datensaetze, string Pfad, string name, ref string fullpath)
        {
            if (!Directory.Exists(Pfad))
            {
                Directory.CreateDirectory(Pfad);
            }
            else
            { }

            FileStream FS = new FileStream(Pfad + "\\" + name + ".csv", FileMode.Create, FileAccess.Write);

            StreamWriter SR = new StreamWriter(FS, Encoding.UTF8);

            string format = "{0};{1};{2};{3}";

            //Titelzeile
            SR.WriteLine(format, "Datum", "Temperatur [°C]", "Luftdruck [hPa]", "Luftfeuchtigkeit [%]");

            foreach (Wetterdaten wd in Datensaetze)
            {
                if (wd.Luftdruck < 700)
                {
                    break;
                }
                else
                { }
                SR.WriteLine(format, wd.Datum, wd.Temperatur.ToString("F2"), wd.Luftdruck.ToString(), wd.Luftfeuchtigkeit.ToString());
            }

            fullpath = FS.Name;
            SR.Close();
            FS.Close();
        }
    }
}