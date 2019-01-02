using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using StaticFileService.Data.Models;

namespace StaticFileService.Data.Repository
{
    public class StaticFileRepo
    {
        public async Task<FileStream> GetStaticFile<TModel>(TModel model) where TModel : StaticFileModel
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                        throw new InvalidOperationException(), @"StaticFiles\" +
                                                                               $"{model.FileDirectory}\\{model.FileName}.{model.Extension}");
            return new FileStream(filePath, FileMode.Open);
        }

        public async Task<IEnumerable<TModel>> GetFilesFromDirectory<TModel>(string directory) where TModel : StaticFileModel
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                        throw new InvalidOperationException(), @"StaticFiles\" + $"{directory}");

            var d = new DirectoryInfo(filePath);
            return d.GetFiles().Select(file => new StaticFileModel(file.Name, file.DirectoryName, d.Extension)) as IEnumerable<TModel>;
        }
    }
}