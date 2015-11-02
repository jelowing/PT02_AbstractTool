using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace PT02_AbstractTool
{
    class Fitxer
    {
        public static void llegir(String nom)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathname = Path.Combine(path, "AbstractTool", nom + ".txt");
            string pathnameSortida = Path.Combine(path, "AbstractTool", nom +"_info"+".txt");
            string content = File.ReadAllText(pathname);
            string fileName = Path.GetFileNameWithoutExtension(pathname);


            Console.Clear();
            Console.WriteLine("Llegint fitxer ...{0}", pathname);
            Console.ReadLine();

            if (File.Exists(pathname))
            {
                FileInfo info = new FileInfo(pathname);   
                    using (StreamWriter sw = new StreamWriter(pathnameSortida,false))
                    {
                        sw.WriteLine("Nom del fitxer: " + info.Name);
                        sw.WriteLine("Extensió: " + info.Extension);
                        sw.WriteLine("Data creació: " + info.CreationTimeUtc);
                        sw.WriteLine("Data de modificació: " + info.LastWriteTimeUtc);
                        sw.WriteLine("Número de paraules: "+comptarParaules(pathname, content));

                    /*Console.WriteLine("Nom del fitxer : {0}", fileName);
                    Console.WriteLine("Extensió : {0}", extensio);
                    Console.WriteLine("Data creació : {0}", dataCreacio);
                    Console.WriteLine("Data última modificació : {0}", dataModificacio);
                    comptarParaules(pathname, content*/

                    Console.WriteLine("Extracció de contingut satisfactoria!");
                    Console.WriteLine("El contingut del fitxer s'ha desat a {0} ",pathnameSortida);

                    }
                
            }
            else
            {
                Console.WriteLine("El fitxer no existeix!");
                Console.ReadKey();
            }
        }


        public static int comptarParaules(string pathFile, string content)
        {
            int paraula = 0;

            File.ReadAllText(pathFile);
            string[] lineas = content.Split();
            foreach (string linea in lineas)
            {
                paraula++;
            }
           
            return paraula;
        }



    }
}



