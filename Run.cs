//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WetterdatenAnalyse2020.Properties;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        struct Wetterdaten
        {
            public string Datum;
            public double Temperatur;
            public uint Luftfeuchtigkeit;
            public uint Luftdruck;
        }
        struct Durchschnitt
        {
            public double Temperatur;
            public double Luftdruck;
            public double Luftfeuchtigkeit;
        }
        static void Run()
        {
            //Zentrale Daten für die Anwendung
            Wetterdaten[] Datensaetze = new Wetterdaten[366];

            #region Testdaten
            DateTime temp = Convert.ToDateTime("1.1.2020");
            for (int index = 0; index < 366; index++)
            {
                Datensaetze[index] = new Wetterdaten();
                Datensaetze[index].Datum = temp.ToShortDateString();
                temp = temp.Date.AddDays(1);
                Datensaetze[index].Temperatur = 23.7 + index;
                Datensaetze[index].Luftdruck = 760 + ((uint)index * 2);
                Datensaetze[index].Luftfeuchtigkeit = 35 + ((uint)index * 2);
            }

            //Standardpfade einstellen
            /*string tempdir = Directory.GetCurrentDirectory();
            Settings.Default.Exportpfad = tempdir + @"\Export";
            Settings.Default.Importpfad = tempdir + @"\Import";
            Settings.Default.Save();*/
            #endregion

            //Lokale Daten für run()
            bool weiter = true;

            //SplashInfos
            Splashinfo();

            //Hauptschleife
            while (weiter)
            {
                //Hauptmenü anzeigen und auswerten
                Console.CursorVisible = false;
                int auswahl = HauptmenueAnzeigenAuswerten();
                switch (auswahl)
                {
                    case 1: //Wetterdaten verwalten
                        WetterdatenVerwalten(ref Datensaetze);
                        break;
                    case 2: //Wetterdaten anzeigen
                        WetterdatenAnzeigen(Datensaetze);
                        break;
                    case 3: //Wetterdaten auswerten
                        WetterdatenAuswerten(Datensaetze);
                        break;
                    case 4: //Wetterdaten importieren
                        WetterdatenImportieren(ref Datensaetze);
                        break;
                    case 5: //Wetterdaten exportieren
                        WetterdatenExportieren(ref Datensaetze);
                        break;
                    case 6: //Pfade konfigurieren
                        Pfadekonfigurieren();
                        break;
                    case 7: //beenden
                        weiter = false;
                        break;
                }
            }

            //Datensicherung
        }
    }
}
