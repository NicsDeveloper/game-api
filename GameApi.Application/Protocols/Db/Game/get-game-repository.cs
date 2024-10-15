namespace GameApi.Application.Protocols.Db.Game;

public interface IGameRepository
{ 
    Task<List<Domain.Models.Game>> Get();
}