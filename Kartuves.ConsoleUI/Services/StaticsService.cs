using Kartuves.BL;
using Kartuves.BL.Interfaces;
using Kartuves.ConsoleUI.Interfaces;
using Kartuves.DL;

namespace Kartuves.ConsoleUI
{
    public class StaticsService : IStatisticsService
    {
        private readonly IPlayerManager _playerManager;
        private readonly IUiMessageFactory _messageFactory;


        public StaticsService()
        {
            _playerManager = new PlayerManager();
            _messageFactory = new UiMessageFactory();
        }

        public void Begin()
        {
            _messageFactory.GamePlayerStatisticsMessage(_playerManager.GetAll());
        }
    }
}
