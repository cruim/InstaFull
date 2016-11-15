using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaTest
{
    public class OperationsWithFile
    {
        public static void DeleteFirstLineFromFile(string x)
        {
            string file_name = x;
            string[] readText = File.ReadAllLines(file_name);
            using (var file = new StreamWriter(file_name, false))
            {
                for (int i = 0; i < readText.Length; i++)
                {
                    if (i != 0) // if(i!=1)
                        file.WriteLine(readText[i]);
                }
            }
        }
    }
}
