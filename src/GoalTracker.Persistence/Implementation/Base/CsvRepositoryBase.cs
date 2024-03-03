using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace GoalTracker.Persistence.Implementation.Base;

public abstract class CsvRepositoryBase
{
    private readonly string _csvFilePath;
    private readonly CsvConfiguration _csvConfiguration;

    protected CsvRepositoryBase(string csvFilePath)
    {
        _csvFilePath = csvFilePath;

        _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine
        };
    }

    protected async Task<IEnumerable<T>> ReadCsvAsync<T>(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            using var reader = new StreamReader(_csvFilePath);
            using var csv = new CsvReader(reader, _csvConfiguration);
            return csv.GetRecords<T>();
        }, cancellationToken);
    }

    protected async Task WriteCsvAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            using var writer = new StreamWriter(_csvFilePath);
            using var csv = new CsvWriter(writer, _csvConfiguration);
            csv.WriteRecords(records);
        }, cancellationToken);
    }
}