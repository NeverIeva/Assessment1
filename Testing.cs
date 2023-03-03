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
            //testing the FisherYates shuffle
            Pack pack = new Pack();
            pack.shuffleCardPack(1);
            pack.dealCard(10).ForEach(Console.WriteLine); //prints 10 random cards doesn't throw any errors
            Console.WriteLine('\n');
            Console.WriteLine(pack.deal().ToString()); //prints out one card
            Console.WriteLine('\n');


            //testing the Riffle shuffle
            Pack newPack = new Pack();
            newPack.shuffleCardPack(2);
            newPack.dealCard(10).ForEach(Console.WriteLine); //10 random cards no errors
            Console.WriteLine('\n');
            Console.WriteLine(newPack.deal().ToString()); //prints out one card
            Console.WriteLine('\n');


            //testing no shuffle
            Pack pack2 = new Pack();
            pack2.shuffleCardPack(3);
            pack2.dealCard(5).ForEach(Console.WriteLine); //unshuffled just prints out ace hearts, 2 hearts, 3 hearts, 4 hearts, 5 hearts etc
            Console.WriteLine('\n');
            Console.WriteLine(pack2.deal().ToString()); //prints out the top card (Ace hearts)
            Console.WriteLine('\n');


            //testing invalid arguments
            pack2.shuffleCardPack(4); //prints out a message saying the shuffle doesn't exist
            Console.WriteLine(pack2.shuffleCardPack(-1).ToString()); //prints out the same message and the return value is False as it should be
            pack2.dealCard(5).ForEach(Console.WriteLine); //no shuffle got applied to the deck

            
            //testing for wrong input and packs being emptied
            Pack pack3 = new Pack();
            while(true)
            {
                Console.WriteLine("How many cards do you want to deal? ");
                int amount = Convert.ToInt32(Console.ReadLine());

                if(amount == 1)
                {
                    try
                    {
                        Console.WriteLine(pack3.deal().ToString());
                    }catch
                    {
                        //due to a guard clause being used the user can choose how to handle this exception
                        Console.WriteLine("Exception caught"); //when the pack becomes empty or the argument is wrong the expection is caught succesfully
                    }
                }
                else
                {
                    try
                    {
                        pack3.dealCard(amount).ForEach(Console.WriteLine);
                    }
                    catch
                    {
                        Console.WriteLine("Exception caught"); //exception is caught when pack is empty and for wrong argument (negatives or more than cards left in pack)
                    }

                    Console.WriteLine(pack3.cardsLeftInPack() + " cards left"); //prints out the correct amount of cards left in the pack
                    
                    if(!pack3.packIsEmpty()) //correctly evaluates if the pack is empty or not
                    {
                        pack3.shuffleCardPack(2); //still shuffles the remaining pack with no error unless the pack is empty in which case error handling can be used
                    }
                    else
                    {
                        Console.WriteLine("The pack is empty can't shuffle it");
                    }
                }

                Console.WriteLine("Continue (1) or exit (2)? ");
                int choice = Convert.ToInt32(Console.ReadLine());

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