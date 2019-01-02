using StaticFileService.Common.Enums;

namespace StaticFileService.Data.Models
{
    public class QuakeSoundModel : StaticFileModel
    {
        public QuakeSoundModel(string fileName, string fileDirectory, string extension, SoundVariation variation) : base(fileName, fileDirectory, extension)
        {
            Variation = variation;
        }

        public SoundVariation Variation { get; set; }
    }
}