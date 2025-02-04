using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpPost]
        [RequestSizeLimit(50 * 1024 * 1024)] // 50 Mb Sınır
        public IActionResult UploadPicture(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Dosya seçilmedi.");
            }

            string a = "";


            files.ForEach(async f =>
            {
                string uploads = Path.Combine("~/Data/Images/Products", "uploads");

                if (f != null)
                {
                   

                    //string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);

                    string dosyaAdi = f.FileName;

                    string filePath = Path.Combine(uploads, dosyaAdi);

                    using (Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        f.CopyTo(stream);
                    }
                }
            });


            return Ok();
        }
    }
}
