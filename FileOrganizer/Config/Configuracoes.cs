namespace FileOrganizer.Config;

public class Configuracoes
{
    public string DestinationDirectory { get; set; } = string.Empty;
    public string SourceDirectory { get; set; } = string.Empty;
    public Dictionary<string, string[]> FileExtensions { get; set; }
}
