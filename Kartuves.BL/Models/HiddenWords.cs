using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartuves.BL.Models
{
    public class HiddenWords
    {
        public HiddenWords(int wordSize)
        {
            CorrectGuesses = new string[wordSize];
            IncorrectGuesses = new List<string>();

        }
        public List<string> IncorrectGuesses { get; set; }
        public string[] CorrectGuesses { get; set; }
        public int HiddenLetterCount => CorrectGuesses.Count(z => z == null);

    }
}
