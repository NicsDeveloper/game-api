using GameApi.Domain.Models;

namespace GameApi.Domain.UseCases;

public interface IGetGames
{
    Task<List<Game>> Get();
}