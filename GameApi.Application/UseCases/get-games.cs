using GameApi.Application.Protocols.Db.Game;
using GameApi.Domain.UseCases;

namespace GameApi.Application.UseCases;

public class GetGames (IGameRepository gameRepository) : IGetGames 
{
    public async Task<List<Domain.Models.Game>> Get()
    {
        var result = await gameRepository.Get();
        return result;
    }
}