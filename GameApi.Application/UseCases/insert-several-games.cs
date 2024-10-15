using GameApi.Application.Protocols.Db.Game;
using GameApi.Domain.Models;
using CsvHelper;
using System.Globalization;

namespace GameApi.Application.UseCases
{
    public class InsertSeveralGames(IGameRepository gameRepository)
    {
        public async Task InsertGamesFromCsv(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            var records = csv.GetRecords<string[]>().ToList();

            var games = records.Select(values => new Game(values[0], values[1], values[2])).ToList();

            await gameRepository.InsertRange(games);
        }
    }
}