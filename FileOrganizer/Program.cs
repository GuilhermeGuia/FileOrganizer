using FileOrganizer.Core.Helpers;
using FileOrganizer.Core.Services;

try
{
    var processor = new FileOrganizer.Core.FileOrganizer();
    processor.Run();
}
catch (Exception e)
{
    Logger.Error(e.Message);
}