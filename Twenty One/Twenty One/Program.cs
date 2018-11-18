using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_One
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();

            deck.Shuffle();

            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }

            Console.WriteLine("Deck Size: " + deck.Cards.Count);
            Console.ReadLine();

        }




    }
}
