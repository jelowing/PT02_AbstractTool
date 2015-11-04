using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace López_Puente_M06UF1PT
{
    class Fitxer
    {
        public static void llegir(String nom)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathname = Path.Combine(path, "AbstractTool", nom + ".txt");
            string pathnameSortida = Path.Combine(path, "AbstractTool", nom +"_info"+".txt");
            string content = File.ReadAllText(pathname).Replace(",","").Replace(".","");
            string fileName = Path.GetFileNameWithoutExtension(pathname);


            Console.Clear();
            Console.WriteLine("Llegint fitxer ...{0}", pathname);
            Console.ReadLine();

            if (File.Exists(pathname))
            {
                FileInfo info = new FileInfo(pathname);   
                    using (StreamWriter sw = new StreamWriter(pathnameSortida,false))
                    {
                        sw.WriteLine("Nom del fitxer: " + Path.GetFileNameWithoutExtension(pathname));
                        sw.WriteLine("Extensió: " + info.Extension);
                        sw.WriteLine("Data creació: " + info.CreationTimeUtc);
                        sw.WriteLine("Data de modificació: " + info.LastWriteTimeUtc);
                        sw.WriteLine("Número de paraules: "+comptarParaules(pathname, content));
                        sw.Write("Tematica: " + ocurrenciesText(pathname, content));


                }

                
                Console.WriteLine("Extracció de contingut satisfactoria!");
                Console.WriteLine("El contingut del fitxer s'ha desat a {0} ", pathnameSortida);

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

        public static string ocurrenciesText(string pathFile, string content)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathDicWords = Path.Combine(path, "AbstractTool", "Dictionary.txt");

            var res = File.ReadLines(pathDicWords).Select((v, i) => new { Index = i, Value = v }).GroupBy(p => p.Index / 2).ToDictionary(g => g.First().Value, g => g.Last().Value);

            //Dictionary<string, string> txtToString = res;
            

            File.ReadAllText(pathFile);
            string[] lineas = content.Split();
            Dictionary<string, int> dic = new Dictionary<string, int>();
           
            
            //IEnumerable LINQ 
            var items = from pair in dic orderby pair.Value descending  select pair;

            int comptador = 0;
            foreach (string s in lineas)
            {
                dic.TryGetValue(s, out comptador);
                dic[s] = comptador + 1;
                
            }

            //Metode per transformar Enumerable to String
            var keys = items.Select(x => String.Format("{0}", x.Key)).ToArray().Except(res.Keys);
            var top5 = keys.Take(5);
            var result = String.Join(", ", top5);



            /*foreach (KeyValuePair<string, int> kvp in top5)
            {
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);             
            }*/

            return result;

        }


    }
}



