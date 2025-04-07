using FileOrganizer.Core.Helpers;

namespace FileOrganizer.Core.Services;

public static class Logger
{
    static Logger()
    {
        var filePath = GetLogPath();
        if (!File.Exists(filePath))
        {
            var createdFile = File.Create(filePath);
            createdFile.Dispose();
        }
    }

    private static string GetLogPath()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        var basePath = currentDirectory[..currentDirectory.IndexOf(@"\bin")];

        return Path.Combine([basePath, "log.log"]);
    }
    private static void WriteLog(string message)
    {
        var file = new FileInfo(GetLogPath());
        var appendText = file.AppendText();

        appendText.Write(message);
        appendText.Dispose();
    }

    public static void Error(string message)
    {
        var text = $@"
""==== ERRO AO UTILIZAR SCRIPT ====""
""ERRO: {message}""";

        Console.WriteLine(text);
        WriteLog(text);
    }
    public static void Sucess(string message) {
        var text = $@"
""====  SUCESSO ====""
""SUCESSO: {message}""";

        Console.WriteLine(text);
        WriteLog(text);
    }
}


