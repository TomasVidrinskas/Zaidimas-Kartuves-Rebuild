using Kartuves.ConsoleUI.Interfaces;


namespace Kartuves.ConsoleUI
{
    class Kartuves
    {
        const int choiseStatistika = 1;
        const int choiseZaidimas = 2;
        static void Main(string[] args)
        {
            IUiMessageFactory messageFactory = new UiMessageFactory();
            var welcommeChoise = messageFactory.WelcomeMessage();
            messageFactory.LoadingMessage();



            if (welcommeChoise == choiseZaidimas)
            {
                IGameService gameService = new GameService();
                gameService.Begin();
            }
            if (welcommeChoise == choiseStatistika)
            { 
                IStatisticsService service = new StaticsService();
                service.Begin();
            }

        }

    }
}
