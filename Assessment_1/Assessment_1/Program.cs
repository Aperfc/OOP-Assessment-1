using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Linq;

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
            string contents = Properties.Resources.Assessment1Data; // getting file data into a variable
            string[] lines = contents.Split("\n"); // splitting each line of the file data
            int seatsAvailable = int.Parse(lines[1]); // getting seats to be won (rounds) from the file data
            foreach (string line in lines)
            {
                if (char.IsLetter(line[0]) == true)
                {
                    string name = line.Split(",")[0];
                    int votes = int.Parse(line.Split(",")[1]);
                    Party party = new Party(new_name: name, new_votes: votes);     //creats a new instance of the class (an object) each time the loop is run, setting specific values for each party
                    parties.Add(party);

                    // Party has now been instantiated, lets add seat names to it
                    List<string> seatNames = line.Split(",").ToList();
                    seatNames.RemoveRange(0, 2); // The first two values aren't seat names, so we remove those, seatNames is now a list of all seat names for this line
                    parties[parties.Count - 1].possibleSeatNames = seatNames; // We're only ever operating on the final value as that's the one we just added, so access the array at count - 1
                }
            }

            //loop for each round
            for (int i = 0; i < seatsAvailable; i++)
            {
                Dictionary<double, Party> votesList = new Dictionary<double, Party>();
                foreach (Party party in parties)
                {
                    votesList.Add(party.votes, party);       //adds the instances votes into a list. the votes are retrieved through a public getter.
                }
                double maxValue = votesList.Keys.Max();      //find which value is the largest in the list or finds what the largest votes number is
                Party winner = votesList[maxValue];

                Console.Write($"The winner is {winner.name} with {winner.votes} votes\n");
                winner.addSeats();

                //this does nothing for now since the seats are not assigned yet meaning that there will be 
                foreach (Party party in parties)
                    party.votesDivision();        //another method is called to divide the votes each round. abstraction too.
            }

            //the code below will write the details of the winners into an output file.
            string path = Directory.GetCurrentDirectory() + @"\output\";        //the directory path i want to place the output text in. the current directory the exe is running from + one directory deeper.
            if (!Directory.Exists(path))         //checks if the fodler is created/there or not
            {
                Directory.CreateDirectory(path);   //creates both additional directory and txt file.
                File.CreateText(path + @"output.txt");        //creates both additional directory and txt file.
            }
            using (StreamWriter sw = new StreamWriter(path + @"output.txt"))
            {
                sw.WriteLine(lines[0]); //The title read in from the vote data
                foreach (Party party in parties)
                {
                    if (party.seats.Count() > 0)
                    {
                        string partyData = "";
                        partyData += party.name;
                        foreach (string seat in party.seats)
                        {
                            partyData += $", {seat}";
                        }
                        partyData += ";";
                        sw.WriteLine(partyData);
                    }
                }
            }
        }
    }
}
