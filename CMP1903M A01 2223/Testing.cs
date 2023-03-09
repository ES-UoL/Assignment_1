using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    //Additional testing class added
    internal class Testing
    {
        public static void Test()
        {
            //Create a pack object
            Pack CardPack = new Pack();
            while (true)
            {
                //Testing menu
                Console.WriteLine("----------------Testing menu----------------\n");
                Console.WriteLine("Enter the number that coresponds to the feature that you wish to test\n");
                Console.WriteLine("1 - Shuffle");
                Console.WriteLine("2 - Deal");
                Console.WriteLine("3 - Display");
                Console.WriteLine("4 - Exit\n");
                int option = 0;
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Format Exception");
                    Console.WriteLine("You must enter a number that corresponds to the feature that you wish to test");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                //Shuffle menu
                if (option == 1)
                {
                    Console.Clear();
                    int shuffleType = 0;
                    while (shuffleType != 1 && shuffleType != 2 && shuffleType != 3 && shuffleType != 4)
                    {
                        Console.WriteLine("----------------Shuffle menu----------------\n");
                        Console.WriteLine("Enter the number that coresponds to the shuffle type that you wish to test\n");
                        Console.WriteLine("1 - Fisher-Yates shuffle");
                        Console.WriteLine("2 - Riffle shuffle");
                        Console.WriteLine("3 - No shuffle");
                        Console.WriteLine("4 - Return to the main menu\n");
                        try
                        {
                            shuffleType = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nError: Format Exception");
                            Console.WriteLine("You must enter a number that corresponds to the required shuffle type");
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        //Fisher-Yates shuffle and display the current order of the pack
                        if (shuffleType == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Fisher-Yates shuffle----------------\n");
                            bool shuffleStatus = Pack.shuffleCardPack(1);
                            if (shuffleStatus)
                            {
                                Console.WriteLine("Fisher-Yates shuffle successful");
                            }
                            else
                            {
                                Console.WriteLine("\nThere was an error with this shuffle method\n");
                                Console.WriteLine("Returning to the main menu");
                                continue;
                            }
                        }
                        //Riffle shuffle and display the current order of the pack
                        else if (shuffleType == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Riffle shuffle----------------\n");
                            bool shuffleStatus = Pack.shuffleCardPack(2);
                            if (shuffleStatus)
                            {
                                Console.WriteLine("Riffle shuffle successful");
                            }
                            else
                            {
                                Console.WriteLine("\nThere was an error with this shuffle method\n");
                                Console.WriteLine("Returning to the main menu");
                                continue;
                            }
                        }
                        //No shuffle and display the current order of the pack
                        else if (shuffleType == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------No shuffle----------------\n");
                            Pack.shuffleCardPack(3);
                        }
                        //Return to the main menu
                        else if (shuffleType == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Returning to the main menu");
                        }
                        //Invalid shuffle type
                        else
                        {
                            Console.WriteLine("\nError: Invalid shuffle type");
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                //Deal
                else if (option == 2)
                {
                    Console.Clear();
                    int dealAmount = -1;
                    while (dealAmount < 0)
                    {
                        Console.WriteLine("----------------Deal----------------\n");
                        Console.WriteLine("How many cards would you like to deal?\n");
                        try
                        {
                            dealAmount = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nError: Format Exception");
                            Console.WriteLine("You must enter a whole number");
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        //Deal no cards
                        if (dealAmount == 0)
                        {
                            Console.WriteLine("\nNo cards dealt");
                        }
                        //Deal one card
                        else if (dealAmount == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Deal one card----------------\n");
                            Pack.dealCard();
                            if (Pack.pack.Count > 0)
                            {
                                Pack.recentlyDealtCards[0].WhatCardIsThis();
                            }
                        }
                        //Deal multiple cards
                        else if (dealAmount > 1)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Deal multiple cards----------------\n");
                            Pack.dealCard(dealAmount);
                            foreach (Card card in Pack.recentlyDealtCards)
                            {
                                card.WhatCardIsThis();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nError: Invalid deal amount");
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                //Display
                else if (option == 3)
                {
                    Console.Clear();
                    int displayType = 0;
                    while (displayType != 1 && displayType != 2 && displayType != 3 && displayType != 4)
                    {
                        Console.WriteLine("----------------Display menu----------------\n");
                        Console.WriteLine("Enter the number that coresponds to the display type that you wish to test\n");
                        Console.WriteLine("1 - Display pack");
                        Console.WriteLine("2 - Display all dealt cards");
                        Console.WriteLine("3 - Display recently dealt cards");
                        Console.WriteLine("4 - Return to the main menu\n");

                        try
                        {
                            displayType = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nError: Format Exception");
                            Console.WriteLine("You must enter a number that corresponds to the required display type");
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        //Display pack
                        if (displayType == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Display pack----------------\n");
                            Console.WriteLine("Here is the current order of the pack:\n");
                            Pack.DisplayPack();
                        }
                        //Display all dealt cards
                        else if (displayType == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Display all dealt cards----------------\n");
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
                        }
                        //Display recently dealt cards
                        else if (displayType == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("----------------Display recently dealt cards----------------\n");
                            if (Pack.recentlyDealtCards.Count == 0)
                            {
                                Console.WriteLine("No cards have been recently dealt");
                            }
                            else
                            {
                                foreach (Card card in Pack.recentlyDealtCards)
                                {
                                    card.WhatCardIsThis();
                                }
                            }
                        }
                        //Return to the main menu
                        else if (displayType == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Returning to the main menu");
                        }
                        //Exception handling
                        else
                        {
                            Console.WriteLine("\nError: You must enter a valid menu option");
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                //Exit
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Program will now terminate\n");
                    Environment.Exit(0);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nError: You must enter a number that corresponds to the feature that you wish to test");
                }
                //Full program loop
                Console.WriteLine("\n\nPress any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
