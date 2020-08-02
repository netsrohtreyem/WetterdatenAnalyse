//Musterlösung Meyer
//Klasse IA119
//Datum 03-05/2020
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WetterdatenAnalyse2020.Properties;

namespace WetterdatenAnalyse2020
{
    partial class main
    {
        static int HauptmenueAnzeigenAuswerten()
        {
            int ergebnis = -1;
            string Menuetext = Resources.Hauptmenue;
            ConsoleKeyInfo input;
            bool ok = false;
            do
            {
                Console.Clear();
                Console.WriteLine(Menuetext);
                Console.WriteLine("\n                       Wählen Sie einen Menüpunkt aus!");
                while (!Console.KeyAvailable) ;
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape)
                {
                    ok = true;
                    ergebnis = 7;
                }
                else if (input.Key == ConsoleKey.C)
                {
                    ergebnis = 6; //konfig
                    ok = true;
                }
                else if (input.Key == ConsoleKey.X)
                {
                    ok = true;
                    ergebnis = 7;
                }
                else
                {
                    ok = int.TryParse(input.KeyChar.ToString(), out ergebnis);
                }
                if (!ok || ergebnis < 0 || ergebnis > 8)
                {
                    Console.Clear();
                    Console.WriteLine("       Bitte nur die angegebenen Ziffern auswählen!");
                    Thread.Sleep(2000);
                }
                else
                { }
            } while (!ok || ergebnis < 0 || ergebnis > 8);

            return ergebnis;
        }
    }
}