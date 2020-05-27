using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DOTNET.BaseProjectTemplate.Core.AspNetCore;
using DOTNET.BaseProjectTemplate.Core.FileStorage;
using DOTNET.BaseProjectTemplate.Core.Utils;
using DOTNET.BaseProjectTemplate.Core.ViewModels;
using DOTNET.BaseProjectTemplate.Core.ViewModels.Enums;
using DOTNET.BaseProjectTemplate.Core.ViewModel;
using DOTNET.BaseProjectTemplate.Core.ViewModel;

namespace DOTNET.BaseProjectTemplate.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class TestController : BaseController
    {
        private readonly IFileStorageService _fileStorageService;

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, IFileStorageService fileStorageService)
        {
            _logger = logger;
            _fileStorageService = fileStorageService;
        }


        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> UploadFile([FromForm]CreateFileVM model)
        {
            var response = new ApiResponse<string>();
            if (ModelState.IsValid)
            {
                var userId = CurrentUser?.UserId;
                var filePaths = TryUploadSupportingDocuments(new List<IFormFile>() { model.Document });
                response.Payload = filePaths.FirstOrDefault();
                if (filePaths.Any())
                    return Ok(response);
            }
            return ApiResponse(ListModelErrors, codes: ApiResponseCodes.INVALID_REQUEST);
        }


        private List<string> TryUploadSupportingDocuments(List<IFormFile> formFiles)
        {
            var filePaths = new List<string>();
            var uploaded = false;
            foreach (var file in formFiles)
            {
                var fileName = CommonHelper.GenerateTimeStampedFileName(file.FileName);
                uploaded = _fileStorageService.TrySaveStream(fileName,
                  file.OpenReadStream());
                if (uploaded)
                    filePaths.Add(fileName);
                else
                    break;
            }

            if (!uploaded && filePaths.Count() > 0)
            {
                foreach (var file in filePaths)
                    _fileStorageService.DeleteFile(file);
            }
            return filePaths;
        }
    }
}
