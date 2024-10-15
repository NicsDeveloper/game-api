namespace GameApi.Application.Protocols.Db.Game
{
    public interface IInsertGameRepository
    {
        Task Insert(Domain.Models.Game game);
        Task InsertRange(IEnumerable<Domain.Models.Game> games);
    }
}