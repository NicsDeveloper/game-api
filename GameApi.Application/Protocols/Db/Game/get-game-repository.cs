using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Application.Protocols.Db.Game
{
    public interface IGameRepository
    {
        Task<List<Domain.Models.Game>> Get();
    }
}