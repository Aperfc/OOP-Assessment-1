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
        private string _name;       //name of the party
        private double _votes;      //number of votes teh party has, this number changes with division after each round
        private List<string> _seats;        //the seast that the party has won
        private List<string> _possibleSeatNames;        //the possible names that the seats could have eg bp1,bp2,bp3,bp4,bp5
        private double _originalVotes;      //the original number of votes that the party was givin in the input file. does not change.
        //getters and setters for the encapsulated(private attributes)
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public double votes
        {
            get
            {
                return _votes;
            }
            set
            {
                _votes = value;
            }
        }
        public List<string> seats
        {
            get
            {
                return _seats;
            }
            set
            {
                _seats = value;
            }
        }
        public List<string> possibleSeatNames
        {
            get
            {
                return _possibleSeatNames;
            }
            set
            {
                _possibleSeatNames = value;
            }
        }
        public double originalVotes
        {
            get
            {
                return _originalVotes;
            }
            set
            {
                _originalVotes = value;
            }
        }

        // a constructor to initialize a new instance of the class
        public Party(string new_name, double new_votes, List<string> new_seats)
        {

            name = new_name;
            votes = new_votes;
            seats = new_seats;
            originalVotes = new_votes;  //this is the orginal votes which should not be changed at all. do not know how to make this into a constant.
            possibleSeatNames = new List<string> { };
        }

        // a method which just writes to the console who has won the round (testing purposes)
        public void status()
        {
            Console.WriteLine($"{_name}\n{_votes}\n{String.Join(",",_seats)}\n\n");
        }

        //method to divide the votes. the _votes attribute is set by the originalvotes / number of seats. this means no matter how many times this is run, as long as the seat count is the same then the votes will be as well
        public void votesDivision()
        {
            //this divides each of the parties votes by the number of seats they have +1 each round
            votes = Math.Round(originalVotes / (seats.Count +1));
        }

        // adds 'seat<number>' to the seats list. no proper name just yet.
        public void addSeats()
        {
            try
            {
                seats.Add(possibleSeatNames[seats.Count]);
            }
            catch (Exception)
            {

                Console.WriteLine("out of range, could not add");
            }
            
        }
        public int getSeatCount()
        {
            return this._seats.Count;
        }
        
    }
}
