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

            do
            {
                int shuffle = 0;
                int amount = 0;

                Console.WriteLine("Cards left in the pack: " + pack3.cardsLeftInPack()); //prints out the correct amount left
                
                //if(!pack3.packIsEmpty()) //correctly identifies if the pack is empty and ends the program if it is
                //{
                    try
                    {
                        Console.WriteLine("What shuffle do you want to use? ");
                        shuffle = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("How many cards do you want to deal? ");
                        amount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("ERROR: Please enter an integer");
                        continue;
                    }

                    pack3.shuffleCardPack(shuffle); //all the shuffles work and when the shuffle number is wrong false is returned an nothing happens to the deck
                //}
                //else
                //{
                //    Console.WriteLine("The pack is now empty");
                //    break;
                //}
                

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
                    if(!pack3.checkIfEnoughCards(amount)) //the user can check if theres enough cards left before calling the method
                    {
                        Console.WriteLine("The amount you entered is not valid, cards left: " + pack3.cardsLeftInPack());
                        continue;
                    }
                    else
                    {
                        pack3.dealCard(amount).ForEach(Console.WriteLine); //successfully deals the cards asked
                    }
                }

                int choice = 0;
                try
                {   
                    Console.WriteLine("Continue (1) or exit (2)? ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("ERROR: Please enter (1) or (2)");
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
            }while(!pack3.packIsEmpty());
        }
    }
}