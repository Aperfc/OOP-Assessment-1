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
            List<Party> parties = new List<Party>();    // creates a list with the data type of our custom object 'Party'
            string contents = Assessment_1.Properties.Resources.Assessment1Data;
            string[] line = contents.Split("\n");
            int seatsAvailable = int.Parse(line[1]);
            foreach (string element in line)
            {
                if (char.IsLetter(element[0]) == true)
                {
                    List<string> emptyList = new List<string> {};
                    string number = element.Split(",")[1];
                    Party placeHolder = new Party(element.Split(",")[0], int.Parse(number), emptyList);     //creats a new instance of the class each time the loop is run, setting the different values
                    parties.Add(placeHolder);
                }
            }

            //adds the possible names to the party objects associate attribute. this allows the correct assigning of seat names.
            int counter3 = 0;
            foreach (string element in line)
            {
                if (char.IsLetter(element[0]) == true)
                {
                    string[] alist = element.Split(",");
                    List<string> templist = new List<string>(alist);
                    foreach (string item in templist.GetRange(2,templist.Count-2))
                    {
                        parties[counter3].possibleSeatNames.Add(item);
                    }
                    //Console.WriteLine(parties[counter3].possibleSeatNames.Count);
                    counter3++;
                }
            }

               //loop for each round
            for (int i = 0; i < seatsAvailable; i++)
            {
                List<double> votesList = new List<double>();
                foreach (Party element in parties)
                {
                    votesList.Add(element.votes);       //adds the instances votes into a list. the votes are achieved through a public getter.
                }
                double maxValue = votesList.Max();      //find which value is the largest in the list or finds what the largest votes number is
                int counter = 0;
                int indexOfWinner = 5;
                foreach (double element in votesList)
                {
                    if(element == maxValue)
                    {
                        indexOfWinner = counter;        //loops through the list of votes and when a party's votes is the same as the maximum then an incremented counter is set as the index value of the winner from. which will be used to select the winner from the parties list
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
                        element.addSeats();     //when the index location matches with the counter in a loop that goes over the parties list; the winner is found. when this happens a method is called. This is a form of ABSTRACTION as the details of the method are hidden, all that the programmers need to know after writing the method is how to use it, the code is then abstracted. this method adds a set to one of the objects attributes
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
                    element.votesDivision();        //another method is called to divide the votes each round. abstraction too.

                }
            }

        }
    }
}
