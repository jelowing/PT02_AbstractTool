using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace López_Puente_M06UF1PT
{
    /// <summary>
    ///  Classe que gestiona el contingut del fitxer
    /// </summary>
    class Fitxer
    {
       /// <summary>
       ///  Mètode estàtic que llegeix el fitxer i n'extreu el contingut
       /// </summary>
       /// <param name="nom">Nom del fitxer</param>
        public static void llegir(String nom)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathname = Path.Combine(path, "AbstractTool", nom + ".txt");
            string pathnameSortida = Path.Combine(path, "AbstractTool", nom +"_info"+".txt");
            string content = File.ReadAllText(pathname).Replace(",", "").Replace(".", "").Replace("?", "").Replace("!", "").Replace("'"," "); ;
            string fileName = Path.GetFileNameWithoutExtension(pathname);


            Console.Clear();
            Console.WriteLine("Llegint fitxer ...{0}", pathname);
            Console.WriteLine(content);
            Console.ReadLine();

            if (File.Exists(pathname))
            { 
                // FileInfo obté la informacio del fitxer amb les seves propietats
                FileInfo info = new FileInfo(pathname);   
                    //StreamWriter que escriu l'informacio del fitxer en un fitxer de sortida
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El contingut del fitxer s'ha desat a {0} ", pathnameSortida);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("El fitxer no existeix!");
                Console.ReadKey();
            }
        }

        /// <summary>
        ///  Mètode estàtic que compta el número de paraules del fitxer
        /// </summary>
        /// <param name="pathFile">Ruta del fitxer</param>
        /// <param name="content">Contingut del fitxer</param>
        /// <returns></returns>
        public static int comptarParaules(string pathFile, string content)
        {
            int paraula = 0;

            File.ReadAllText(pathFile);
            string[] lineas = content.Split();
            foreach (string linea in lineas)
            {
                if (linea == "d" || linea == "l" || linea == "s" || linea == "n") {
                    paraula--;
                }
                paraula++;
            }
           
            return paraula;
        }




        /// <summary>
        /// Mètode estàtic que mostra les cinc paraules amb mes ocurrencies en el fitxer
        /// </summary>
        /// <param name="pathFile">Ruta del fitxer</param>
        /// <param name="content">Contingut del fitxer</param>
        /// <returns></returns>
        public static string ocurrenciesText(string pathFile, string content)
        {
            // Ruta que agafa el Escriptori del usuari indiferentment del SO
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int comptador = 0;

            File.ReadAllText(pathFile);
            string[] lineas = content.Split();

            Dictionary<string, int> dic = new Dictionary<string, int>();
            
            // Per cada paraula en el fitxer, obtenim la key del diccionari i l'anem incrementant
            foreach (string s in lineas)
            {
                dic.TryGetValue(s, out comptador);
                dic[s] = comptador + 1;
 
            }

            //IEnumerable LINQ 
            var items = from pair in dic orderby pair.Value descending select pair;

            //Transformar Enumerable to String , extreiem totes les paraules que s'han afegit al diccionari,
            // excepte les de la funcio LoadXML(), i agafem les 5 que més ocurrencies tenen.
            var keys = items.Select(x => String.Format("{0}", x.Key)).ToArray().Except(LoadXML());
            var top5 = keys.Take(5);
            var result = String.Join(", ", top5);

            /*foreach(KeyValuePair<string, int> kvp in dic)
            {
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);             
            }*/
            //Regex.Replace(result, @"\s+", " ");
            return result;

        }

        /// <summary>
        /// Mètode estàtic que retorna un IEnumerable i carrega un diccionari a partir d'un XML
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> LoadXML()
        {
            var xml = XDocument.Load("C:\\Users\\Jenifer López\\Desktop\\AbstractTool\\Dictionary.xml");
            var root = xml.Root.DescendantNodes().OfType<XElement>();
            var words = new Dictionary<string, string>();
            foreach (var node in root)
            {
                words.Add(node.Name.ToString(), node.Value);
            }
           
            return words.Values;
        }

        


    }
}



