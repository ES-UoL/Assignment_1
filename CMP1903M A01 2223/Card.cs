using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Fields
        /*Encapsulation has been used to protect these fields by making them private and providing a controlled level 
        of access through the public properties and constructor*/
        private int _value;
        private int _suit;

        //Properties with set method validation
        public int Value
        {
            get { return _value; }
            set 
            { 
                if (value < 1 || value > 13)
                {
                    throw new ArgumentOutOfRangeException("The value of the card must be between 1 and 13 (inclusive)");
                }
                else
                {
                    _value = value; 
                }
            }
        }
        public int Suit
        {
            get { return _suit; }
            set 
            {
                if (value < 1 || value > 4)
                {
                    throw new ArgumentOutOfRangeException("The suit number of the card must be between 1 and 4 (inclusive)");
                }
                else
                {
                    _suit = value; 
                }
            }
        }

        //Card Constructor
        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        //Methods
        //This is an additional method that has been added beyond what was provided in the base code
        /*
        Abstraction is used here to map the card's numerical value and suit to their corresponding names 
        using dictionaries, resulting in a more user-friendly representation of the card. 
        The underlying implementation details of the cards are concealed from the user, which simplifies 
        the code and makes it more maintainable.
        */
        public void WhatCardIsThis()
        {
            //Value: numbers 1 - 13
            var Values = new Dictionary<int, string>()
            {
                {1, "Ace"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Jack"},
                {12, "Queen"},
                {13, "King"}
            };
            //Suit: numbers 1 - 4
            var Suits = new Dictionary<int, string>()
            {
                {1, "Spades"},
                {2, "Hearts"},
                {3, "Diamonds"},
                {4, "Clubs"}
            };
            Console.WriteLine($"{Values[Value]} of {Suits[Suit]} ({Value} : {Suit})");
        }
    }
}
