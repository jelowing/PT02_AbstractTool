using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace López_Puente_M06UF1PT
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
                else
                {
                    Console.WriteLine("Arxius a : {0}", dir+"\n");
                }
                try {

                    string[] fileEntries = Directory.GetFiles(dir);
                    foreach (string f in fileEntries)
                    {
                        Console.WriteLine(Path.GetFileName(f));
                        
                    }
                    Console.WriteLine();
                    Console.WriteLine("Nom del arxiu: ");
                    string file = Console.ReadLine();
                    Fitxer.llegir(file);

                }
                catch (Exception e)
                {
                    Console.WriteLine("No existeix el fitxer o hi ha problemas amb el xml");
                }

                    
                    Console.WriteLine("\n"+"Vols introduir un altre fitxer? y|n");
                    Boolean ok = false;

                do {
                    string input = Console.ReadLine();
                    if (input == "y" || input == "Y")
                    {
                        final = true;
                        Console.Clear();
                        ok = true;
                    }
                    else if (input == "n" || input == "N")
                    {
                        final = false;
                        Console.WriteLine("Prem una tecla per sortir ...");
                        ok = true;
                    } else
                    {
                        Console.WriteLine("El caràcter introduït no es vàlid, introdueix y o n");
                        ok = false;
                    }
                } while (!ok);


            } while (final);

            Console.ReadKey();

        }

    }
}
