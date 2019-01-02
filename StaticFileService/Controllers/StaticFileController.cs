using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaticFileService.Common.Enums;
using StaticFileService.Common.Processing;
using StaticFileService.Data.Models;
using StaticFileService.Data.Repository;

namespace StaticFileService.Controllers
{
    [Route("api/[controller]")]
    public class StaticFileController : Controller
    {
        private readonly StaticFileRepo _repo = new StaticFileRepo();

        [HttpGet("[action]")]
        public async Task<IEnumerable<QuakeSoundModel>> GetAllQuakeSoundsAsync()
        {
            return await _repo.GetFilesFromDirectory<QuakeSoundModel>("QuakeSounds");
        }

        [HttpGet("[action]")]
        public async Task PlayQuakeSound([FromQuery] string fileName, [FromQuery] SoundVariation variation = SoundVariation.Male)
        {
            var model = new QuakeSoundModel(fileName, "QuakeSounds", ".wav", variation);

            var result = await Get<QuakeSoundModel>(model);
        }

        /// <summary>
        /// Gets static files by TModel.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> Get<TModel>(TModel model)
            where TModel : StaticFileModel
        {
            var result = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                var request = new ProcessingRequest<StaticFileModel>
                {
                    //Temporary Repo access, need to go back and build out processors and interfaces. 
                    File = await _repo.GetStaticFile<TModel>(model)
                };
                result.Content = new StreamContent(request.File);

                return result;
            }

            catch (Exception e)
            {
                return null;
            }
        }
    }
}