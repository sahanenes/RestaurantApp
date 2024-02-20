using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialsService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            testimonialsService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(testimonialsService.TGetLIstAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            testimonialsService.TAdd(new Testimonial()
            {
                Status = createTestimonialDto.Status,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title
            });
            return Ok("Testimonial was added successfuly");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = testimonialsService.TGetById(id);
            testimonialsService.TDelete(value);
            return Ok("Testimonial was deleted successfuly");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {

            var value = testimonialsService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            testimonialsService.TUpdate(new Testimonial
            {
                Status = updateTestimonialDto.Status,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                TestimonialID = updateTestimonialDto.TestimonialID

            });
            return Ok("Testimonial was updated successfuly");
        }
    }
}

