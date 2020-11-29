using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kartuves.BL.Interfaces;
using Kartuves.BL.Models;
using Kartuves.DL;

namespace Kartuves.BL
{
    public class HiddenWordManager : IHiddenWordManager
    {
        private readonly Words _words;

        public HiddenWords HiddenWords { get; set; }

        public HiddenWordManager(Words word)
        {
            _words = word;
            HiddenWords = new HiddenWords(_words.Text.Length);
        }
        public HiddenWords GetHiddenWord()
        {

            return HiddenWords;
        }
        public string GetHiddenWordsStructure()
        {

            Console.WriteLine();
            var sb = new StringBuilder("Zodis: ");
            foreach (var raide in HiddenWords.CorrectGuesses)
            {
                if (string.IsNullOrWhiteSpace(raide)) sb.Append("_ ");
                else sb.Append($"{raide} ");
            }
            return sb.ToString();

        }
        public void CheckLetter(string spejimas)
        {
            var zodisArr = _words.Text.ToCharArray();
            var raidesIndeksai = new List<int>();
            for (int i = 0; i < _words.Text.Length; i++)
            {
                if (zodisArr[i].ToString().ToUpper() == spejimas.ToUpper()) raidesIndeksai.Add(i);
            }


            if (raidesIndeksai.Count == 0)
            {
                HiddenWords.IncorrectGuesses.Add(spejimas);
            }
            else
            {
                PridetiRaideITeisingaViataZodyje(spejimas, raidesIndeksai);
            }
        }
        private void PridetiRaideITeisingaViataZodyje(string spejimas, List<int> raidesIndeksas)
        {
            foreach (int indeksas in raidesIndeksas)
            {
                HiddenWords.CorrectGuesses[indeksas] = spejimas;
            }
        }

    }
}
