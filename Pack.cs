using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private List<Card> pack = new List<Card>();

        public Pack()
        {
            //Initialises the pack class
            //Adds one card of each value for each suit 
            for(int i=1; i<5; i++)
            {
                for(int j=1; j<14; j++)
                {
                    pack.Add(new Card(j, i));
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            //1 = Fisher-Yates Shuffle, 2 = Riffle Shuffle
            bool shuffled = false;
            if(typeOfShuffle == 1)
            {
                pack = Shuffle.FisherYates(pack);
                shuffled = true;
            }
            else if(typeOfShuffle == 2)
            {
                pack = Shuffle.Riffle(pack);
                shuffled = true;
            }
            else if(typeOfShuffle == 3)
            {
                //3 is no shuffle so this part doesn't do anything to the pack just confirms that theres no error
                shuffled = true;
            }
            else
            {
                //if any other typeOfShuffle nothing happens and the function returns false so the user knows the arg they gave was incorrect
                Console.WriteLine("That shuffle does not exist, no shuffle has been applied to your deck of cards"); //either change to a guard clause or keep it as it is
                shuffled = false;
            }

            return shuffled;
        }
        public Card deal()
        {      
            if(pack.Count == 0)
            {
                throw new ArgumentNullException("This pack of cards is empty");
            }

            return pack[0];
        }
        
        //returns a list with the number of cards specified
        public List<Card> dealCard(int amount)
        {
            List<Card> cards = new List<Card>();

            //check that the amount is possible to give out if not return a an empty list and write to the console
            if(amount > 52 || amount < 1)
            {
                throw new ArgumentException("The amount of cards is invalid, it should be between 1 and 52");
            }
            else
            {
                cards = pack.Take(amount).ToList();
            }

            return cards;
        }

        //a method that gives the string representation of the Pack class, so when printed the cards are written on a seperate line
        public override string ToString()
        {
            return string.Join('\n', pack);
        }
        
    }
}
