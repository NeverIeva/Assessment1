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
            pack.dealCard(5).ForEach(Console.WriteLine); //prints 5 random cards doesn't throw any errors
            Console.WriteLine('\n');
            Console.WriteLine(pack.deal().ToString()); //prints out the same first card as in the dealCard(5)
            Console.WriteLine('\n');

            
            //testing the Riffle shuffle
            Pack newPack = new Pack();
            newPack.shuffleCardPack(2);
            newPack.dealCard(5).ForEach(Console.WriteLine); //5 random cards no errors
            Console.WriteLine('\n');
            Console.WriteLine(newPack.deal().ToString()); //same top card as the one from dealCard(5)
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

            try
            {
                pack2.dealCard(60).ForEach(Console.WriteLine); //this threw an exeption as its supposed to and it printed out the statemt in the catch block 
                //same for arg < 1
            }
            catch
            {
                Console.WriteLine("Exception caught");
            }

        }
    }
}