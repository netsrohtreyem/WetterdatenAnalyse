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
        static void Pfadekonfigurieren()
        {
            Console.Clear();
            Console.WriteLine("Aktueller Pfade:");
            Console.Write("Exportpfad: " + Settings.Default.Exportpfad + "\n\n");
            Console.Write("Importpfad: " + Settings.Default.Importpfad + "\n\n");
            Console.WriteLine("Welchen Pfad möchten sie ändern: (E)xport oder (I)mport? abbrechen mit (ESC)");

            while (!Console.KeyAvailable) ;
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.E)
            {
                Console.WriteLine("Geben Sie den neuen vollständigen Export - Pfad an:");
                string neu = Console.ReadLine();

                if (!Directory.Exists(neu))
                {
                    try
                    {
                        Directory.CreateDirectory(neu);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Der Pfad konnte nicht gesetzt werden! " + e.Message);
                        return;
                    }
                }
                else
                { }
                Settings.Default.Exportpfad = neu;
            }
            else if (input.Key == ConsoleKey.I)
            {
                Console.WriteLine("Geben Sie den neuen vollständigen Import - Pfad an:");
                string neu = Console.ReadLine();

                if (!Directory.Exists(neu))
                {
                    try
                    {
                        Directory.CreateDirectory(neu);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Der Pfad konnte nicht gesetzt werden! " + e.Message);
                        return;
                    }
                }
                else
                { }
                Settings.Default.Importpfad = neu;
            }
            else
            { }

            Settings.Default.Save();
        }
    }
}