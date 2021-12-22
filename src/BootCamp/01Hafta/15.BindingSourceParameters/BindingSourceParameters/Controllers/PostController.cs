using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BindingSourceParameters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly string _targetFilePath= "C:\tmp";
        [HttpPost]
        public void Post([FromForm] byte[] file, string filename)
        {
            var trustedFileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_targetFilePath, trustedFileName);

            if (System.IO.File.Exists(filePath))
            {
                return;
            }

            System.IO.File.WriteAllBytes(filePath, file);
        }

        [HttpPost("Profile")]
        public void SaveProfile([FromForm] ProfileViewModel model)
        {
            var trustedFileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_targetFilePath, trustedFileName);

            if (System.IO.File.Exists(filePath))
            {
                return;
            }

            System.IO.File.WriteAllBytes(filePath, model.File);
        }

        public class ProfileViewModel
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
        }
    }
}
