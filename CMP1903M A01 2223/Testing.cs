using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        static void Main(string[] args)
        {
            // Create a pack object
            Pack CardPack = new Pack();

            // Display the default order of the pack
            Console.WriteLine("\n----------------Default ordered pack----------------\n");
            Pack.DisplayPack();

            // Shuffle types

            // Riffle shuffle and display the current order of the pack
            Console.WriteLine("\n----------------Riffle shuffle----------------\n");
            bool ShuffleStatus = Pack.shuffleCardPack(2);
            if (ShuffleStatus)
            {
                Console.WriteLine("Riffle shuffle successful");
            }
            Console.WriteLine("\nHere is the current order of the pack:\n");
            Pack.DisplayPack();

            // Fisher-Yates shuffle and display the current order of the pack
            Console.WriteLine("\n----------------Fisher-Yates shuffle----------------\n");
            bool ShuffleStatus2 = Pack.shuffleCardPack(1);
            if (ShuffleStatus2)
            {
                Console.WriteLine("Fisher-Yates shuffle successful");
            }
            Console.WriteLine("\nHere is the current order of the pack:\n");
            Pack.DisplayPack();

            // No shuffle and display the current order of the pack
            Console.WriteLine("\n----------------No shuffle----------------\n");
            Pack.shuffleCardPack(3);
            Console.WriteLine("Here is the current order of the pack:\n");
            Pack.DisplayPack();

            // Invalid shuffle type and display the current order of the pack
            Console.WriteLine("\n----------------Invalid shuffle type----------------\n");
            bool ShuffleStatus3 = Pack.shuffleCardPack(4);
            if (!ShuffleStatus3)
            {
                int ShuffleType = 0;
                while (ShuffleType != 1 && ShuffleType != 2 && ShuffleType != 3)
                {
                    Console.WriteLine("Error: Invalid shuffle type\n\nThe shuffle type number must be set to either:\n1 - Fisher-Yates shuffle\n2 - Riffle shuffle\n3 - No shuffle\n");
                    Console.WriteLine("Please enter the valid shuffle type here:");
                    ShuffleType = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                Pack.shuffleCardPack(ShuffleType);
                Console.WriteLine("Here is the current order of the pack:\n");
                Pack.DisplayPack();
            }

            // Deal methods

            // Deal one card
            Console.WriteLine("\n ----------------Deal and display one card---------------- \n");
            Pack.dealCard().WhatCardIsThis();
            Console.WriteLine("\n ----------------Display pack again after deal---------------- \n");
            Pack.DisplayPack();

            // Deal multiple cards
            Console.WriteLine("\n ----------------Deal and display multiple cards---------------- \n");
            Pack.dealCard(5);
            foreach (Card card in Pack.recentlyDealtCards)
            {
                card.WhatCardIsThis();
            }
            Console.WriteLine("\n ----------------Display pack again after multi-deal---------------- \n");
            Pack.DisplayPack();

            // Display all dealt cards
            Console.WriteLine("\n ----------------Display all dealt cards---------------- \n");
            if (Pack.dealtCards.Count == 0)
            {
                Console.WriteLine("No cards have been dealt yet");
            }
            else
            {
                foreach (Card card in Pack.dealtCards)
                {
                    card.WhatCardIsThis();
                }
            }

            // Pause program before termination
            Console.ReadKey();
        }
    }
}
