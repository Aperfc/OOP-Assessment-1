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
        private string _name;
        private double _votes;
        private List<string> _seats;
        private List<string> _possibleSeatNames;
        private double _originalVotes;
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

        public Party(string new_name, double new_votes, List<string> new_seats)
        {

            name = new_name;
            votes = new_votes;
            seats = new_seats;
            originalVotes = new_votes;
        }

        public void status()
        {
            Console.WriteLine($"{_name}\n{_votes}\n{String.Join(",",_seats)}\n\n");
        }

        public void votesDivision()
        {
            //this hopefull divides each of the parties votes by the number of seats they have +1 each round
            votes = Math.Round(_originalVotes / (_seats.Count +1));
        }

        // literally just adds 'seat<number> to the seats list. no proper name just yet.
        public void addSeats()
        {
            seats.Add($"seat{(seats.Count)+1}");
        }
        
    }
}
