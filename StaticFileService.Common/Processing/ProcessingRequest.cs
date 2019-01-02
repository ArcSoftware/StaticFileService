using System.IO;

namespace StaticFileService.Common.Processing
{
    public class ProcessingRequest<TModel>
    {
        public TModel Item { get; set; }
        public FileStream File { get; set; }
    }
}