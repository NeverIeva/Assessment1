using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903M_A01_2223
{
    class Shuffle
    {
        //class with the algorithms for the shuffling
        public static List<Card> FisherYates(List<Card> deck)
        {
            //throw an exception to the user if the deck of cards is empty
            if(deck.Count == 0)
            {
                throw new ArgumentNullException("The deck of cards is empty");
            }

            //starts form the end on the list, generates a random number
            Random random = new Random();
            for(int i=deck.Count-1; i>0; i--)
            {
                int n = random.Next(0, i+1);

                //swap the Card on that random index with the curent Card
                Card temp = deck[i];
                deck[i] = deck[n];
                deck[n] = temp;
            }

            return deck;
        }



        public static List<Card> Riffle(List<Card> deck) //change this so it starts either at the left or right
        {
            //throw an exception to the user if the deck of cards is empty
            if(deck.Count == 0)
            {
                throw new ArgumentNullException("The deck of cards is empty");
            }

            //randomly generates a number of times to shuffle the deck of card (at least 7 times because thats the min to achive 'randomness' at least in real life)
            Random random = new Random();
            int n = random.Next(7, 27);

            for(int i=0; i<n; i++)
            {
                //split the deck into 2, left and right
                List<Card> left = deck.Take(deck.Count/2).ToList();
                List<Card> right = deck.Skip(deck.Count/2).Take(deck.Count/2).ToList();
                List<Card> newDeck = new List<Card>();

                //generate a 0 or a 1 to decide if the left and right decks should swap to make this shuffle more 'random'
                int swap = random.Next(0,2);

                if(swap == 1) 
                {
                    List<Card> temp = left;
                    left = right;
                    right = temp;
                }

                //to a new deck alterate between adding the top card off of left deck and then the right

                while(left.Count() > 0 && right.Count > 0) //once there are no cards left in the left deck that means all the cards have been added to the new merged one
                {
                    newDeck.Add(left[0]);
                    newDeck.Add(right[0]);
                    left.RemoveAt(0);
                    right.RemoveAt(0);
                }

                deck = newDeck;
            }

            return deck;
            
        }

    }
}