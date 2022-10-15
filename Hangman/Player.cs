using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<char> guessedLetters { get; } = new List<char>();

    public Player(string name)
    {
        this.Name= name;
    } 
}
}

