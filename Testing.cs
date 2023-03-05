using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        public Testing()
        {
            //testing all the shuffles and deal methods as well as error handling
            Pack pack3 = new Pack();
            while(true)
            {
                int shuffle = 0;
                int amount = 0;
                
                if(!pack3.packIsEmpty()) //correctly identifies if the pack is empty and ends the program if it is
                {
                    try
                    {
                        Console.WriteLine("What shuffle do you want to use? ");
                        shuffle = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("How many cards do you want to deal? ");
                        amount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Please enter an integer");
                        continue;
                    }

                    pack3.shuffleCardPack(shuffle); //all the shuffles work and when the shuffle number is wrong false is returned an nothing happens to the deck
                }
                else
                {
                    Console.WriteLine("The pack is now empty");
                    break;
                }
                

                if(amount == 1)
                {
                    if(!pack3.packIsEmpty()) //the user can check if the pack is empty and if it is they can close the program
                    {
                        Console.WriteLine(pack3.deal().ToString()); //successfully deals one card
                    }
                    else
                    {
                        Console.WriteLine("The pack is empty");
                        break;
                    }
                }
                else
                {
                    if(pack3.cardsLeftInPack()-amount < 0 || amount < 0) //the user can check if theres enough cards left before calling the method
                    {
                        Console.WriteLine("The amount is more than cards left in the deck, cards left: " + pack3.cardsLeftInPack());
                        continue;
                    }
                    else
                    {
                        pack3.dealCard(amount).ForEach(Console.WriteLine); //successfully deals the cards asked
                    }

                    Console.WriteLine(pack3.cardsLeftInPack() + " cards left"); //prints out the correct amount of cards left in the pack
                }

                int choice = 0;
                try
                {   
                    Console.WriteLine("Continue (1) or exit (2)? ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter an int");
                    continue;
                }
                
                if(choice == 1)
                {
                    continue;
                }
                else if(choice == 2)
                {
                    break;
                }
            }
        }
    }
}