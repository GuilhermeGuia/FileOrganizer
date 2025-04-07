using System.Text.Json;

namespace FileOrganizer.Config;

public static class ConfigService
{
    public static Configuracoes GetConfigJson()
    {
        var filePath = GetFilePath();

        if (!File.Exists(filePath)) throw new Exception("O arquivo de configuração não foi encontrado.");

        var jsonString = File.ReadAllText(filePath);
        var mappedConfigs = JsonSerializer.Deserialize<Configuracoes>(jsonString);

        return mappedConfigs ?? throw new Exception("O arquivo de configuração não está correto.");
    }

    private static string GetFilePath()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        var basePath = currentDirectory[..currentDirectory.IndexOf(@"\bin")];
        
        return Path.Combine([basePath, "Config", "config.json"]);
    }
}
