using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PT02_AbstractTool
{
    class Fitxer
    {
        public static void llegir(String nom)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathname = Path.Combine(path, "AbstractTool", nom + ".txt");
            string extensio = Path.GetExtension(pathname);

            Console.Clear();
            Console.WriteLine("Llegint fitxer ...{0}", pathname);
            Console.ReadLine();

            if (File.Exists(pathname))
            {
                string content = File.ReadAllText(pathname);
                DateTime dataCreacio = File.GetCreationTimeUtc(pathname);
                DateTime dataModificacio = File.GetCreationTimeUtc(pathname);

                Console.WriteLine("Nom del fitxer : {0}", Path.GetFileNameWithoutExtension(pathname));
                Console.WriteLine("Extensió : {0}", extensio);
                Console.WriteLine("Data creació : {0}", dataCreacio);
                Console.WriteLine("Data última modificació : {0}", dataModificacio);
                comptarParaules(pathname, content);

                /*Console.WriteLine(content);
                Console.ReadLine();*/
            }
            else
            {
                Console.WriteLine("El fitxer no existeix!");
                Console.ReadKey();
            }
        }


        public static void comptarParaules(string pathFile, string content)
        {
            int paraula = 0;

            File.ReadAllText(pathFile);
            string[] lineas = content.Split();
            foreach (string linea in lineas)
            {
                paraula++;
            }
            Console.WriteLine("Numero de paraules : {0}", paraula);
            Console.ReadLine();
        }


    }
}



