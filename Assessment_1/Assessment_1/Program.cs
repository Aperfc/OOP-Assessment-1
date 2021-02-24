using System;
using System.IO;
using System.Resources;

namespace Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader("../../../Resources/Assessment1Data.txt");


            string word = Assessment_1.Properties.Resources.Assessment1Data;
            string[] words = word.Split("\n");
            foreach (string a in words)
            {
                Console.WriteLine(a);
            }
            string x = Console.ReadLine();

            //Console.WriteLine(sr.ReadToEnd());
            //Console.WriteLine(lines);


            //var assembly = Assembly.GetExecutingAssembly();
            //var name = "Assessment_1.Properties.Resources.Assessment1Data.txt";
            //using (Stream stream = assembly.GetManifestResourceStream(name))
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string lines = reader.ReadToEnd();
            //}
        }
    }
}
