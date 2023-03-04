using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Suits: 1=hearts, 2=diamonds, 3=spades, 4=clubs
        //Values: 1=Ace, 2=2, 3=3, 4=4,...,11=Jack, 12=Queen, 13=King

        private int _value;
        private int _suit;

        public int Value
        {
            get {return _value;}
            private set
            {
                if(value >= 1 && value <= 13)
                {
                    _value = value;
                }
                else
                {
                    Console.WriteLine("The value is invalid");
                }
            }
        }

        public int Suit
        {
            get {return _suit;}
            private set
            {
                if(value >= 1 && value <= 4)
                {
                    _suit = value;
                }
                else
                {
                    Console.WriteLine("The suit is invalid");
                    //close app?
                }
            }
        }

        public Card(int _Value, int _Suit)
        {
            Value = _Value;
            Suit = _Suit;
        }

        //string rep of the Card class, in the form [Value] [Suit], and converts the int value to an actual card name (eg. 1 2 = Ace Diamonds)
        public override string ToString()
        {
            string Val;
            string SuitName;

            switch(Value)
            {
                case(1):
                    Val = "Ace";
                    break;
                case(11):
                    Val = "Jack";
                    break;
                case(12):
                    Val = "Queen";
                    break;
                case(13):
                    Val = "King";
                    break;
                default: //the value of everything that isn't 1, 11, 12 or 13 is just the int value that it already has
                    Val = Convert.ToString(Value);
                    break;
            }

            switch(Suit)
            {
                case(1):
                    SuitName = "Hearts";
                    break;
                case(2):
                    SuitName = "Diamonds";
                    break;
                case(3):
                    SuitName = "Spades";
                    break;
                case(4):
                    SuitName = "Clubs";
                    break;
                default:
                    //if for some reason the suit isn't one of these then it'll just asign the suit as Unknown (technically shouldn't even happen)
                    SuitName = "Unknown";
                    break;
            }

            return Val + " " + SuitName;
        }
    }
}
