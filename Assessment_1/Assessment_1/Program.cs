using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Linq;
//COMMENT TO TEST COLABORATIVE WORK

/*what need to be done now is divide the votes,
 * add a method to the class to assign seats with appriopriate names
 * make the code more efficeint as it uses too many for loops.
 */
namespace Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Party> parties = new List<Party>();
            string contents = Assessment_1.Properties.Resources.Assessment1Data;
            string[] line = contents.Split("\n");
            int seatsAvailable = int.Parse(line[1]);
            foreach (string element in line)
            {
                if (char.IsLetter(element[0]) == true)
                {
                    List<string> emptyList = new List<string> {};
                    string number = element.Split(",")[1];
                    Party placeHolder = new Party(element.Split(",")[0], int.Parse(number), emptyList);
                    parties.Add(placeHolder);
                }
            }
               //loop for each round
            for (int i = 0; i < seatsAvailable; i++)
            {
                List<double> votesList = new List<double>();
                foreach (Party element in parties)
                {
                    votesList.Add(element.votes);
                }
                double maxValue = votesList.Max();
                int counter = 0;
                int indexOfWinner = 5;
                foreach (double element in votesList)
                {
                    if(element == maxValue)
                    {
                        indexOfWinner = counter;
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                int counter2 = 0;
                foreach (Party element in parties)
                {
                    if(counter2 == indexOfWinner)
                    {
                        Console.WriteLine($"the winner is {element.name} with {element.votes} votes");
                        element.addSeats();
                        break;
                    }
                    else
                    {
                        counter2++;
                    }
                }

                //this does nothing for now since the seats are not assigned yet meaning that there will be 
                foreach (Party element in parties)
                {
                    element.votesDivision();

                }
            }

        }
    }
}
