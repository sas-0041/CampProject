using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;

        public ImagesController(IImageService imageSevice)
        {
            _imageService = imageSevice;
        }

        [HttpGet("getallbyimage")]
        public IActionResult GetAllByImage()
        {
            var result = _imageService.GetAllByImage();
            if (result.Success )
            {
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpGet("getimagebycarid")]
        public IActionResult GetImageByCarId(int carId)
        {
            var result=_imageService.GetImageByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name =("Image"))]IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
