using FileOrganizer.Core.Helpers;

namespace FileOrganizer.Core.Services
{
    public class FileProcessor
    {
        private readonly string[] _sourceFiles;
        private readonly string _destinationDirectoryPath;
        private readonly Random _random;
        public FileProcessor(string[] sourceFiles, string destinationDirectoryPath)
        {
            _sourceFiles = sourceFiles;
            _destinationDirectoryPath = destinationDirectoryPath;
            _random = new Random();
        }
        public void Process()
        {
            foreach (var file in _sourceFiles)
            {
                var fileName = Path.GetFileName(file);
                var finalPath = MountFinalPath(file);

                FileExtensions.CreateDirectory(finalPath);

                try
                {
                    var destFilePath = Path.Combine(finalPath, fileName);
                    FileExtensions.MoveFile(file, destFilePath, fileName);
                }
                catch (IOException _)
                {
                    var newFileName = RenameFile(file);

                    var destFilePath = Path.Combine(finalPath, newFileName);

                    FileExtensions.MoveFile(file, destFilePath, newFileName);
                }
                catch (UnauthorizedAccessException e)
                {
                    Logger.Error(e.Message);
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                }
            }
        }
        private string GetPathFileDate(string file)
        {
            var fileCreateTime = File.GetCreationTime(file);

            return $"{fileCreateTime.Year}-{fileCreateTime.Month}";
        }

        private string MountFinalPath(string file)
        {
            var fileExt = Path.GetExtension(file);

            var pathFileDate = GetPathFileDate(file);

            var fileCategory = CategoryClassifier.GetCategoryByExtension(fileExt);

            return Path.Combine([_destinationDirectoryPath, fileCategory, pathFileDate]);
        }

        private string RenameFile(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var fileExt = Path.GetExtension(file);

            return $"{fileName}_{_random.Next()}{fileExt}";
        }
    }
}
