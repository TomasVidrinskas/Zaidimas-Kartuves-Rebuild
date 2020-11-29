using Kartuves.ConsoleUI.Interfaces;
using Kartuves.ConsoleUI.Services;
using Kartuves.DL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kartuves.ConsoleUI
{
    public class UiMessageFactory : IUiMessageFactory
    {
        private readonly IPictureFactory _pictureFactory;

        public UiMessageFactory()
        {
            _pictureFactory = new PictureFactory();
        }
        public int WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Zaidimas Kartuves");
            Console.WriteLine();
            Console.WriteLine("Pasirinkite:");
            Console.WriteLine("1. Statistika");
            Console.WriteLine("2. Zaidimas");

            int i = 0;


            while (i == 0)
            {
                var choise = Console.ReadKey().KeyChar;
                int.TryParse(choise.ToString(), out i);
                if (i == 0) Console.WriteLine("\n {0} Ivedete ne skaitmeni, bandyk dar karta", i);
            }
            return i;
        }
        public void LoadingMessage()
        {
            Console.Clear();
            Console.WriteLine("Palaukite");
        }

        public string LoginMessage()
        {
            Console.Clear();
            Console.WriteLine("Iveskite savo varda:");
            Console.WriteLine();
            return Console.ReadLine();
        }

        public string WordInputMessage()
        {
            Console.WriteLine("Spekite raide ar zodi:");
            return Console.ReadLine();
        }

        public void LostMessage(string zodis)
        {
            Console.WriteLine("");
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine("Pralaimejote");
            Console.WriteLine("Zodis buvo {0}", zodis);


        }
        public void WinMessage(string zodis)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine("Sveikiname LAIMEJOTE");
            Console.WriteLine("Zodis buvo {0}", zodis);


        }
        public void KartuvesPictureMessage(int incorrectGuessCount)
        {
            _pictureFactory.DisplayPicture(incorrectGuessCount);
        }
        public bool RepeatGameMessage()
        {
            Console.WriteLine("Pakartoti zaidima? T/N");
            return Console.ReadKey().KeyChar.ToString().ToUpper() == "T";

        }

        public void IncorrectLettersListMessage(List<string> neteisingiSpejimai)
        {
            Console.Write("\nSpetos raides: ");
            foreach (var neteisingasSpejimas in neteisingiSpejimai)
            {
                Console.Write($"{neteisingasSpejimas}");
            }
        }
        public void PlayerStatisticsMessage(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine($"Zaidejas {player.Name} zaide {player.ScoreBoards.Count} kartus");
            Console.WriteLine($"Is ju laimejo {player.ScoreBoards.Count(z => z.IsCorrect)}");
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine();
            Console.WriteLine("Spausk klavisa kad testi");
            Console.ReadKey();

        }
        public void GamePlayerStatisticsMessage(List<Player> players)
        {
            Console.Clear();
            foreach (var player in players)
            {
                Console.WriteLine("===========================================================================================================");
                Console.WriteLine($"Zaidejas {player.Name} zaide {player.ScoreBoards.Count} kartus");
                Console.WriteLine($"Is ju laimejo {player.ScoreBoards.Count(z => z.IsCorrect)} ");
                Console.WriteLine("===========================================================================================================");
                Console.WriteLine();
            }

            Console.WriteLine("Spausk klavisa kad baigti");
            Console.ReadKey();

        }


    }
}
