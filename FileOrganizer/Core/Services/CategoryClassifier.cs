using FileOrganizer.Config;

namespace FileOrganizer.Core.Services;

public static class CategoryClassifier
{
    public static string GetCategoryByExtension(string ext)
    {
        var fileExtensions = ConfigService.GetConfigJson().FileExtensions;
        var mapped = fileExtensions.FirstOrDefault(x => x.Value.Contains(ext));

        if (string.IsNullOrWhiteSpace(mapped.Key)) return "Desconhecidos";

        return mapped.Key;
    }
}
