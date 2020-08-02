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
        static void WetterdatenVerwalten(ref Wetterdaten[] Datensaetze)
        {
            bool fertig = false;
            do
            {
                int menueauswahl = MenueWetterdatenVerwalten();
                switch (menueauswahl)
                {
                    case 1://Wetterdaten hinzufügen
                        WetterdatenHinzufuegen(ref Datensaetze);
                        fertig = false;
                        break;
                    case 2://Wetterdaten bearbeiten
                        WetterdatenBearbeiten(ref Datensaetze);
                        fertig = false;
                        break;
                    case 3://Wetterdaten löschen
                        WetterdatenLoeschen(ref Datensaetze);
                        fertig = false;
                        break;
                    case 4:
                        fertig = true;
                        break;
                    default:
                        fertig = true;
                        break;
                }
            } while (!fertig);
        }
    }
}