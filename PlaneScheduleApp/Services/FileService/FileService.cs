namespace PlaneScheduleApp.Services.FileService;

public class FileService : IFileService
{
    public string GetDefaultFilePath(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("Filename can't be null or empty");
        }
        
        // created files will be saved to Debug or Release folder, path chosen for demo purposes only
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return Path.Combine(currentDirectory, fileName);
    }

    public string ReadFromFile(string filePath)
    {
        try
        {
            var fileData = File.ReadAllText(filePath);
            return fileData;
        }
        catch (Exception)
        {
            Console.WriteLine($"Can't read data from provided file path: {filePath}");
            throw;
        }
    }

    public void WriteToFile(MemoryStream memoryStream, string filePath)
    {
        try
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(fileStream);
        }
        catch (Exception)
        {
            Console.WriteLine($"Can't write data into file with provided path: {filePath}");
            throw;
        }
    }
}