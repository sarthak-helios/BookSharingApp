using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Authorization;

namespace BookSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IWebHostEnvironment _env) : ControllerBase
    {
        [HttpGet("{file}")]
        public IActionResult GetFile([FromRoute] string file, [FromQuery] int s = 400)
        {
            try
            {
                string folder = Path.Combine(_env.WebRootPath, "images");
                string filePath = Path.Combine(folder, file);
                if (s>=4000)
                {
                    s=4000;
                }
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }
                using (var image = Image.Load(filePath))
                {
                    var originalWidth = image.Width;
                    var originalHeight = image.Height;
                    var ratio = (double)originalWidth / originalHeight;
                    int newWidth, newHeight;

                    if (originalWidth > originalHeight)
                    {
                        newWidth = s;
                        newHeight = (int)(s / ratio);
                    }
                    else
                    {
                        newWidth = (int)(s * ratio);
                        newHeight = s;
                    }

                    image.Mutate(x => x.Resize(newWidth, newHeight));
                    var ext = Path.GetExtension(filePath).ToLower();
                    IImageEncoder encoder = ext switch
                    {
                        ".jpg" => new JpegEncoder(),
                        ".jpeg" => new JpegEncoder(),
                        ".png" => new PngEncoder(),
                        _ => new JpegEncoder()
                    };

                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, encoder);
                    ms.Position = 0;

                    return new FileStreamResult(ms, $"image/{ext.Replace(".", "")}");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                string folder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split('.')[^1];
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { file=fileName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }

        }
    }
}
