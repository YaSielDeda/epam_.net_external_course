using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgov_Task_1._2
{
    public class FileReader
    {
        public static string[] ReadFileInArr(string fileName)
        {
            string[] textArr;

            try
            {
                textArr = File.ReadAllText(fileName).Split();
            }
            catch (FileNotFoundException ex)
            {
                textArr = null;
                Console.WriteLine(ex.Message);
            }

             return textArr;
        }

        public static string ReadFile(string fileName)
        {
            string text;

            try
            {
                text = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException ex)
            {
                text = null;
                Console.WriteLine(ex.Message);
            }

            return text;
        }
    }
}
