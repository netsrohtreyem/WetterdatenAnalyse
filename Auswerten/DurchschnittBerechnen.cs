//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static Durchschnitt DurchschnittBerechnen(Wetterdaten[] Datensaetze)
        {
            Durchschnitt ergebnis = new Durchschnitt();
            int anzahl = 0;

            #region Zählen
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
                return ergebnis;
            #endregion

            for (int index = 0; index < anzahl; index++)
            {
                ergebnis.Temperatur += Datensaetze[index].Temperatur;
                ergebnis.Luftdruck += Datensaetze[index].Luftdruck;
                ergebnis.Luftfeuchtigkeit += Datensaetze[index].Luftfeuchtigkeit;
            }
            ergebnis.Temperatur /= anzahl;
            ergebnis.Luftdruck /= anzahl;
            ergebnis.Luftfeuchtigkeit /= anzahl;

            return ergebnis;
        }
    }
}