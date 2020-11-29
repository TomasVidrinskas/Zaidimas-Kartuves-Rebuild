using Kartuves.DL;
using System.Collections.Generic;

namespace Kartuves.ConsoleUI.Interfaces
{
    public interface IUiMessageFactory
    {
        void GamePlayerStatisticsMessage(List<Player> players);
        void IncorrectLettersListMessage(List<string> neteisingiSpejimai);
        void KartuvesPictureMessage(int incorrectGuessCount);
        void LoadingMessage();
        string LoginMessage();
        void LostMessage(string zodis);
        void PlayerStatisticsMessage(Player player);
        bool RepeatGameMessage();
        int WelcomeMessage();
        void WinMessage(string zodis);
        string WordInputMessage();
    }
}
