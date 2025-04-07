using FileOrganizer.Config;
using FileOrganizer.Core.Helpers;
using FileOrganizer.Core.Services;

namespace FileOrganizer.Core;

public class FileOrganizer
{
    public void Run()
    {
        var configs = ConfigService.GetConfigJson();

        var destinationDirectory = configs.DestinationDirectory;
        var sourceDirectory = configs.SourceDirectory;

        if (!Directory.Exists(destinationDirectory) || string.IsNullOrWhiteSpace(destinationDirectory)) throw new Exception("A pasta de destino não existe ou nao foi corretamente especificada.");

        if (!Directory.Exists(sourceDirectory) || string.IsNullOrWhiteSpace(sourceDirectory)) throw new Exception("A pasta de origem não existe ou nao foi corretamente especificada.");

        var sourceFiles = Directory.GetFiles(sourceDirectory);
        if (sourceFiles.Length == 0) throw new Exception("A pasta de origem não possui arquivos para mapear.");

        FileExtensions.CreateDirectory(destinationDirectory);

        var fileProcess = new FileProcessor(sourceFiles, destinationDirectory);
        fileProcess.Process();
    }
}
