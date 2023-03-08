using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        //Fields
        public static List<Card> pack = new List<Card>();
        public static List<Card> packFirstHalf = new List<Card>();
        public static List<Card> packSecondHalf = new List<Card>();
        public static List<Card> dealtCards = new List<Card>();
        public static List<Card> recentlyDealtCards = new List<Card>();

        //Pack Constructor
        public Pack()
        {
            int x = 1;
            int y = 1;
            while(y != 5)
            {
                pack.Add(new Card(x, y));
                x++;
                if (x == 14)
                {
                    x = 1;
                    y++;
                }
            }
        }

        //Methods
        //Shuffles the pack based on the type of shuffle
        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Fisher-Yates Shuffle
            if (typeOfShuffle == 1)
            {
                Random random = new Random();
                for (int i = 0; i < pack.Count; i++)
                {
                    int j = random.Next(i, pack.Count);
                    Card temp = pack[i];
                    pack[i] = pack[j];
                    pack[j] = temp;
                }
                return true;
            }

            //Riffle Shuffle
            else if (typeOfShuffle == 2)
            {
                if (pack.Count == 52)
                {
                    packFirstHalf.AddRange(pack.GetRange(0, 26));
                    packSecondHalf.AddRange(pack.GetRange(26, 26));
                    int i = 0;
                    int j = 0;
                    while (i != 52)
                    {
                        pack[i] = packFirstHalf[j];
                        i++;
                        pack[i] = packSecondHalf[j];
                        i++;
                        j++;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: The riffle shuffle method can only be performed on a full pack of 52 cards");
                    return false;
                }
            }

            //No Shuffle
            else if (typeOfShuffle == 3)
            {
                Console.WriteLine("The Pack was not shuffled and so the cards\nremain in the same order as they were before");
                return true;
            }

            //Exception
            else 
            {
                return false;
            }
        }
        //Deals one card
        public static Card dealCard()
        {
            recentlyDealtCards.Clear();
            if (pack.Count == 0)
            {
                Console.WriteLine("The pack is empty");
                return null;
            }
            else
            {
                Card TopCard = pack[0];
                pack.RemoveAt(0);
                recentlyDealtCards.Add(TopCard);
                dealtCards.AddRange(recentlyDealtCards);
                return TopCard;
            }

        }
        //Deals the number of cards specified by 'amount'
        public static List<Card> dealCard(int amount)
        {
            recentlyDealtCards.Clear();
            if (pack.Count == 0)
            {
                Console.WriteLine("The pack is empty");
                return null;
            }
            else if (pack.Count < amount)
            {
                Console.WriteLine($"It is not possible to deal {amount} cards since there are only {pack.Count} cards left in the pack");
                return null;
            }
            else
            {
                for (int i = 1; i <= amount; i++)
                {
                    Card TopCard = pack[0];
                    pack.RemoveAt(0);
                    recentlyDealtCards.Add(TopCard);
                }
                dealtCards.AddRange(recentlyDealtCards);
                return recentlyDealtCards;
            }

        }
        // Display pack
        public static void DisplayPack()
        {
            if (pack.Count == 0)
            {
                Console.WriteLine("The pack is empty");
            }
            else
            {
                int count = 1;
                foreach (Card card in pack)
                {
                    Console.Write($"{count}. ");
                    card.WhatCardIsThis();
                    count++;
                };
            }

        }
    }
}
