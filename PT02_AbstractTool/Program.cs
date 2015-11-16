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
            string[] fileEntries = Directory.GetFiles(dir, "*.txt");
            bool final = true;
            int index = 0;


            
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    Console.WriteLine("S'ha creat el directori {0}", Path.GetFileName(dir));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Carrega els arxius en aquesta ruta {0}", dir);
                    Console.ReadKey();
                    Environment.Exit(0);
                }


                 do { 

                    Console.WriteLine("Arxius a : {0}", dir+"\n");

                    carregaArxius(dir,index);
                
                    Console.WriteLine();
                    Console.WriteLine("Introdueix el numero del fitxer : ");
                    string file = Console.ReadLine();



                try {
                    Fitxer.llegir(Path.GetFileNameWithoutExtension(fileEntries[int.Parse(file)]));
                }catch(Exception e)
                {
                    Console.WriteLine("El caràcter introduït no és un número o el número introduit no és a la llista");
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

        public static void carregaArxius(string dir, int index)
        {
            string[] fileEntries = Directory.GetFiles(dir, "*.txt");

            foreach (string f in fileEntries)
            {
                Console.WriteLine(index + " - " + Path.GetFileName(f));
                index++;
            }
        }


    }
}
