using System;
using System.Collections.Generic;
using System.Text;

// encountered a problem with converting double to float when doing the devision so i decided to make the seats and _seats attributes a double data type.
// i think i resolved the LOGICAL ERROR i had (needed to empty the votes list in program.cs) which means i think that the double can be changed back to float
// too lazy to do that now.

namespace Assessment_1
{
    class Party
    {
        //attributes of the object
        public string name;       //name of the party
        public double votes;      //number of votes the party has, this number changes if the party wins the round
        public List<string> seats = new List<string>();        //the list of seats that the party has won
        public List<string> possibleSeatNames = new List<string>();        //the possible names that the seats could have eg bp1,bp2,bp3,bp4,bp5
        public double originalVotes;      //the original number of votes that the party was givin in the input file. does not change.

        // a constructor to initialize a new instance of the class
        public Party(string new_name, double new_votes)
        {
            name = new_name;
            votes = new_votes;
            originalVotes = new_votes;  //this is the orginal votes which should not be changed at all. do not know how to make this into a constant.
            seats = new List<string>();
            possibleSeatNames = new List<string>();
        }

        //method to divide the votes. the _votes attribute is set by the originalvotes / number of seats. 
        //this means no matter how many times this is run, as long as the seat count is the same then the votes will be as well
        //this divides each of the parties votes by the number of seats they have +1 each round
        public void votesDivision() => votes = Math.Round(originalVotes / (seats.Count + 1));

        // adds 'seat<number>' to the seats list. no proper name just yet.
        public void addSeats() => seats.Add(possibleSeatNames[seats.Count]);
        
    }
}
