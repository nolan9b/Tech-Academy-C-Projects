using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_One
{
    public class Card
    {
        // Constructor Method
 
        
        // Properties
        public Suit Suit { get; set; }
        public string Face { get; set; }
        // Methods
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

}
