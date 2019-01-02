namespace StaticFileService.Data.Models
{
    public class StaticFileModel
    {
        public StaticFileModel(string fileName, string fileDirectory, string extension)
        {
            FileName = fileName;
            FileDirectory = fileDirectory;
            Extension = extension;
        }

        public string FileName { get; set; }
        public string FileDirectory { get; set; }
        public string Extension { get; set; }
    }
}