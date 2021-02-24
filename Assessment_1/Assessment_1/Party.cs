using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_1
{
    class Party
    {
        private string _name;
        private float _votes;
        private List<string> _seats;
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
        public float votes
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

        public Party(string new_name, float new_votes, List<string> new_seats)
        {

            name = new_name;
            votes = new_votes;
            seats = new_seats;
        }

        public void status()
        {
            Console.WriteLine($"{_name}\n{_votes}\n{String.Join(",",_seats)}\n\n");
        }

        public void votesDivision()
        {
            //this hopefull divides each of the parties votes by the number of seats they have +1 each round
            Math.Round(_votes /= (_seats.Count +1));
        }
        
    }
}
