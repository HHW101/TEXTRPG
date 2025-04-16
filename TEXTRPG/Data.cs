using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;


namespace TEXTRPG
{ 
    class Data
    {
        private static Data instance;
        string filePath;
        public static string key = "12345";
        public static Data Instance()
        {
            if(instance == null)
            {
                instance = new Data();
            }
            return instance;
        }
        
       public void initData()
        {
            filePath = @"savefolder\save.txt";
            var directory = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directory);
          //  File.WriteAllText(filePath, "안녕하세요");
        }
       public List<string> LoadData()
        {
            List<string> data = new List<string>();
            if (File.Exists(filePath)) {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    if (reader.ReadLine() != key)
                        return null;
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        
                        data.Add(line);

                    }



                }

                return data;
            }
            return null;
            
            
         
        }

        public void SaveData(string player, List<string> items, List<string> shops, string edata)
        {
            using(StreamWriter sw = new StreamWriter(filePath))
                {
                sw.WriteLine(key);
                sw.WriteLine(player);
               
                foreach (string item in items) {
              
                    sw.WriteLine(item);
                }
                sw.WriteLine(key);
                sw.WriteLine(edata);
                foreach (string shop in shops)
                { 
                    sw.WriteLine(shop);
                }


            }

        }



    }
}
