using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
//COMMENT TO TEST COLABORATIVE WORK
namespace Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Party> parties = new List<Party>();
            string contents = Assessment_1.Properties.Resources.Assessment1Data;
            string[] line = contents.Split("\n");
            foreach (string element in line)
            {
                if (char.IsLetter(element[0]) == true)
                {
                    Console.WriteLine("hit");
                    List<string> emptyList = new List<string> {};
                    string number = element.Split(",")[1];
                    Party placeHolder = new Party(element.Split(",")[0], int.Parse(number), emptyList);
                    parties.Add(placeHolder);
                }
            }
            foreach (Party element in parties)
            {
                element.status();
            }
        }
    }
}
