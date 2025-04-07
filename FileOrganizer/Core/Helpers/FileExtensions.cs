using FileOrganizer.Config;
using FileOrganizer.Core.Services;
using System.Text.Json;

namespace FileOrganizer.Core.Helpers
{
    public static class FileExtensions
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Logger.Sucess("CRIANDO DIRETÓRIO.");
            }
        }
        public static void MoveFile(string file, string destFilePath, string fileName)
        {
            File.Move(file, destFilePath);
            Logger.Sucess($"Movendo arquivo {fileName} para a pasta {destFilePath}");
        }
    }
}
