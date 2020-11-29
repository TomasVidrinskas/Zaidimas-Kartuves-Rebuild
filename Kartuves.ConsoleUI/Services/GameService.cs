using Kartuves.ConsoleUI.Interfaces;
using Kartuves.DL;
using Kartuves.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kartuves.BL.Interfaces;
using System.Data.Entity;


namespace Kartuves.ConsoleUI
{
    public class GameService : IGameService, IRandomize
    {
        private readonly IUiMessageFactory _messageFactory;
        private readonly List<Subject> _subjects;
        private readonly IRandomUnits _randomUnits;
        private readonly IPlayerManager _playerManager;
        private IHiddenWordManager _hiddenWordManager;
        const int gyvybiuKiekis = 7;
        public int guessWholeWord;

        List<Words> panaudotiZodziai = new List<Words>();


        public GameService()
        {
            _messageFactory = new UiMessageFactory();
            _randomUnits = new RandomUnits();
            IReadRepository wordManager = new WordManager();
            _subjects = wordManager.GetAllSubjects();
            _playerManager = new PlayerManager();
        }

        public void Begin()
        {
            var userName = _messageFactory.LoginMessage();
            var user = _playerManager.GetByUserName(userName);
            if (user == null)
            {
                var key = _playerManager.Add(new Player { Name = userName });
                user = _playerManager.Get(key);
            }
            _messageFactory.PlayerStatisticsMessage(user);
            bool kartoti = true;
            List<Words> PanaudotiZodziai = new List<Words>() { null };

            while (kartoti)
            {
                Console.Clear();
                var tema = RenkuosiTema();
                var zodis = RandomZodzioParinkimas(tema, PanaudotiZodziai);
                if (zodis == null)
                {
                    Console.WriteLine("Temoje nebera zodziu, ar norite rinktis kita tema t/n");
                }
                else
                {
                    _hiddenWordManager = new HiddenWordManager(zodis);
                    bool leidziamaSpeti = true;
                    panaudotiZodziai.Add(zodis);
                    _messageFactory.KartuvesPictureMessage(0);
                    Console.WriteLine();
                    Console.WriteLine(_hiddenWordManager.GetHiddenWordsStructure());
                    while (leidziamaSpeti)
                    {
                        string spejimas = _messageFactory.WordInputMessage();
                        bool arSpetasZodis = ArSpetasZodis(spejimas);
                        if (arSpetasZodis)
                        {
                            bool arTeisinga = ArZodisTeisingas(zodis.Text, spejimas);

                            if (arTeisinga)
                            {
                                _messageFactory.WinMessage(zodis.Text);
                                guessWholeWord = _hiddenWordManager.HiddenWords.HiddenLetterCount;
                            }
                            else
                            {
                                _messageFactory.KartuvesPictureMessage(gyvybiuKiekis);
                                _messageFactory.LostMessage(zodis.Text);
                            }
                            leidziamaSpeti = false;
                        }
                        else
                        {
                            bool arBuvoSpeta = _hiddenWordManager.HiddenWords.IncorrectGuesses.Contains(spejimas);
                            if (!arBuvoSpeta)
                            {
                                _hiddenWordManager.CheckLetter(spejimas);
                            }
                            if (_hiddenWordManager.HiddenWords.IncorrectGuesses.Count == gyvybiuKiekis)
                            {
                                _messageFactory.KartuvesPictureMessage(gyvybiuKiekis);
                                _messageFactory.LostMessage(zodis.Text);
                                leidziamaSpeti = false;
                            }
                            else
                            {
                                Console.Clear();
                                _messageFactory.KartuvesPictureMessage(_hiddenWordManager.HiddenWords.IncorrectGuesses.Count);
                                _messageFactory.IncorrectLettersListMessage(_hiddenWordManager.HiddenWords.IncorrectGuesses);
                                Console.WriteLine(_hiddenWordManager.GetHiddenWordsStructure());
                                if (_hiddenWordManager.HiddenWords.HiddenLetterCount == 0)
                                {
                                    _messageFactory.WinMessage(zodis.Text);
                                   _messageFactory.PlayerStatisticsMessage(user);
                                    leidziamaSpeti = false;
                                }
                            }
                        }                                            
                    }
                   _playerManager.AddScoreBoards(GetScoreBoard(zodis, user.PlayerId));
                    //nors ir atnaujinu duomenu baze cia
                }
                guessWholeWord = 0;
                //bet visada atspauzdina senos duomenu bazes duomenis, neissiaiskinau kodel taip yra
                _messageFactory.PlayerStatisticsMessage(user);
                kartoti = _messageFactory.RepeatGameMessage();
            }
        }
        private ScoreBoard GetScoreBoard(Words word, int userId)
        {
            return new ScoreBoard
            {
                PlayerId = userId,
                DatePlayed = DateTime.Now,
                GuessCount = _hiddenWordManager.HiddenWords.IncorrectGuesses.Count + _hiddenWordManager.HiddenWords.CorrectGuesses.Count(z => z != null),
                IsCorrect = _hiddenWordManager.HiddenWords.HiddenLetterCount == guessWholeWord,
                WordId = word.WordId
            };
        }
        private Words RandomZodzioParinkimas(Subject tema, List<Words> PanaudotiZodziai)
        {
            var zodziai = tema.Words;
            Words zodis = null;
            bool temojeZodziaiBaigesi = false;
            while (PanaudotiZodziai.Contains(zodis))
            {
                zodis = zodziai[_randomUnits.Random(0, zodziai.Count)];
                if (PanaudotiZodziai.Count >= 11)
                {
                    temojeZodziaiBaigesi = true;
                    break;
                }
            }
            PanaudotiZodziai.Add(zodis);
            if (temojeZodziaiBaigesi) return null;
            return zodis;
        }
        private bool ArZodisTeisingas(string zodis, string spejimas)
        {
            return zodis.ToUpper() == spejimas.ToUpper();
        }

        private bool ArSpetasZodis(string spejimas)
        {
            return spejimas.Length > 1;

        }

        private Subject RenkuosiTema()
        {
            Console.WriteLine("Pasirinkite tema:");
            int ivestasTemosNr = 0;
            IsveskTemuPavadinimus();
            while (ivestasTemosNr > _subjects.Count || ivestasTemosNr == 0)
            {
                var temosChar = Console.ReadKey().KeyChar;
                int.TryParse(temosChar.ToString(), out ivestasTemosNr);
                if (ivestasTemosNr > _subjects.Count || ivestasTemosNr == 0) Console.WriteLine("\n {0} temos nera, bandyk dar karta", ivestasTemosNr);
            }
            Console.Clear();
            Console.WriteLine("\n Tema: {0}", _subjects[ivestasTemosNr - 1]);

            return _subjects[ivestasTemosNr - 1];
        }

        private void IsveskTemuPavadinimus()
        {
            for (int i = 0; i < _subjects.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _subjects[i].Name);
            }
        }



    }
}
