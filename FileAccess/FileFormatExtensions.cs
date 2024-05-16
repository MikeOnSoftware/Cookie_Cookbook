namespace Cookie_Cookbook.FileAccess
{
    public static class FileFormatExtensions
    { //extension method for the FileFormat enum, cause no methods can be added to the enum directly
        public static string AsFileExtension(this FileFormat fileFormat) =>
            fileFormat == FileFormat.Json ? "json" : "txt";
    }
}
