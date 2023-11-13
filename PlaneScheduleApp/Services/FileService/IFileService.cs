namespace PlaneScheduleApp.Services.FileService;

public interface IFileService
{
    string GetDefaultFilePath(string fileName);
    string ReadFromFile(string filePath);
    void WriteToFile(MemoryStream memoryStream, string filePath);
}