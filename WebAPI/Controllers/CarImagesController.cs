using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        //Add
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Delete
        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var carDeleteImage = _carImageService.GetByImageId(carImage.Id).Data;
            var result = _carImageService.Delete(carDeleteImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetAll
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetById
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetByCarId
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
