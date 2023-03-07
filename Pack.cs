using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private List<Card> pack = new List<Card>(); //private to prevent any cheating in the games so no one can access it except from within a class

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
                Console.WriteLine("That shuffle does not exist, no shuffle has been applied to your deck of cards");
                shuffled = false;
            }

            return shuffled;
        }
        public Card deal()
        {   
            //first checks to make sure the pack is not empty if it is throw an exception for the user to catch
            Card oneCard;
            if(pack.Count == 0)
            {
                Console.WriteLine("The pack of cards is empty");
                throw new ArgumentNullException("This pack of cards is empty");
            }
            else
            {
                //after the first review: added a feture to remove the cards from the pack after they are dealt

                oneCard = pack[0]; //chooses a card from the top of the pack and removes it from the pack
                pack.RemoveAt(0);

                if(pack.Count == 0) //if the pack is now empty it will print a message to the user
                {
                    Console.WriteLine("The pack is now empty");
                }
            }

            return oneCard;
        }
        
        //returns a list with the number of cards specified
        public List<Card> dealCard(int amount)
        {
            List<Card> cards = new List<Card>();

            //check that the amount is possible to give out if not return a an empty list and write to the console
            if(amount > pack.Count || amount < 0)
            {
                Console.WriteLine("The pack of cards has " + pack.Count + " cards left, please choose between 0 and that ammount of cards");

                //since a guard clause is used the user can choose how to deal with this exception
                throw new ArgumentException("The amount of cards is invalid, it should be between 1 and " + pack.Count.ToString()); 
            }
            else
            {
                //after first review: added feature to remove the cards dealt from the pack 

                //takes the amount of card specified and removes them from the pack
                cards = pack.Take(amount).ToList();
                pack.RemoveRange(0, amount);

                if(pack.Count == 0) //if the pack is now empty it will print out a message to the user
                {
                    Console.WriteLine("The pack is now empty");
                }
            }

            return cards;
        }

        //since the pack is a private list, this method tells the user the amount of cards left in the pack
        public int cardsLeftInPack()
        {
            return pack.Count;
        }

        //method for the user to check if the pack is empty or not
        public bool packIsEmpty()
        {
            if(pack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfEnoughCards(int n)
        {
            if(pack.Count - n < 0 & n > 0 | n < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //a method that gives the string representation of the Pack class, so when printed the cards are written on a seperate line
        public override string ToString()
        {
            return string.Join('\n', pack);
        }
        
    }
}
