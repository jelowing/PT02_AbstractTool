﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PT02_AbstractTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dir = Path.Combine(path, "AbstractTool");
            bool final = true;

            do
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    Console.WriteLine("S'ha creat el directori {0}", Path.GetFileName(dir));
                    Console.WriteLine("Carrega els arxius en aquesta ruta {0}", dir);
                    Console.ReadKey();
                }

                Console.WriteLine("Nom del arxiu: ");
                string file = Console.ReadLine();
                Fitxer.llegir(file);
                Console.WriteLine("Vols introduir un altre fitxer? y|n");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    final = true;
                }
                else if (input == "n")
                {
                    final = false;
                }

            } while (final);

            Console.ReadKey();

        }

    }
}