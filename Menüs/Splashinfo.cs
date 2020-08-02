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
        static void Splashinfo()
        {
            string Splashtext = Resources.Splashinfo;

            Console.WriteLine(Splashtext);
            Thread.Sleep(6000);
        }
    }
}