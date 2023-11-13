using PlaneScheduleApp.Services.FileService;

namespace PlaneScheduleApp.Services.DataOutputProvider;

public class DataOutputResolver
{
    private readonly IFileService _fileService;

    public DataOutputResolver(IFileService fileService)
    {
        _fileService = fileService;
    }

    public IDataOutputProvider Resolve(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Console => new ConsoleDataOutputProvider(),
            OutputType.FileSystem => new FileDataOutputProvider(_fileService),
            _ => throw new ArgumentOutOfRangeException($"{outputType} is not supported")
        };
    }
}