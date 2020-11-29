using Kartuves.DL;

namespace Kartuves.BL.Interfaces
{
    public interface IPlayerManager : ICRUDRepository<Player>
    {
        void AddScoreBoards(ScoreBoard scoreBoard);
        Player GetByUserName(string userName);
    }
}
