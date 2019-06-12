using System;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToFileCSV(CountResult(','));
            SaveToFileTXT(CountResult('\t'));
        }

        static string ReadFromFileCSV()
        {
            string result = "";

            using (StreamReader reader = new StreamReader(@"C:\Temp\Lab3.csv"))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        static string ReadFromFileTXT()
        {
            string result = "";

            using (StreamReader reader = new StreamReader(@"C:\Temp\Lab3.txt"))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        static double[] CountResult(char separator)
        {
            string data = "";
            data = separator == ',' ? ReadFromFileCSV() : ReadFromFileTXT();

            var dataAfterFirstSplit = data.Split("\r\n");
            var resultArray = new double[5];
            for (int i = 0; i < 5; i++)
            {
                var stringTriangle = dataAfterFirstSplit[i].Split(separator);
                resultArray[i] = CountFormula(Convert.ToInt32(stringTriangle[0]), Convert.ToInt32(stringTriangle[0]),
                    Convert.ToInt32(stringTriangle[0]));
            }

            return resultArray;
        }

        static double CountFormula(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double result = (2 / a) * (Math.Sqrt(p * (p - a) * (p - c)));
            return result;
        }

        static void SaveToFileCSV(double[] result)
        {
            using (StreamWriter writter = new StreamWriter(@"C:\Temp\Lab3Result.csv"))
            {
                foreach (var res in result)
                {
                    writter.WriteLine(res);
                }
            }
        }
        static void SaveToFileTXT(double[] result)
        {
            using (StreamWriter writter = new StreamWriter(@"C:\Temp\Lab3Result.txt"))
            {
                foreach (var res in result)
                {
                    writter.WriteLine(res);
                }
            }
        }
    }
}
